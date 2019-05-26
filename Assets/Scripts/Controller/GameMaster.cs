using System;
using System.Collections;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    //Singleton
    public static GameMaster instance;

    public static bool dead = false;
    public static int coinTotal = 0;
    public static float timeTotal = 0;


    public float zPos = 16;
    public Transform coinObj;
    public Transform obstObj;
    public Transform capsuleObj;
    public Transform platform;

    //Random # for what we gonna instantiate (0 to 10}
    public int randonNumber;
    //Random Value for x {-1,0,1}
    public int randx;

    private AudioSource audioSource;


    private void Awake()
    {
        MakeSingleton();
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        zPos = 6;
        for (int i = 0; i < 7; i++)
        {
            //Start with 7 Tiles
            CreateTiles();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Calculating Time of Gameplay
        if (!dead)
            timeTotal += Time.deltaTime;
        else
            StopAllCoroutines();

    }

    void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    //Play Sound of Coin when taken
    public void PlayCollectableSound()
    {
        audioSource.Play();
    }

    /*
     * RandomNumber idea was from google
     * The idea is Splitting Random Number to section to Guarntee no Collission between the Instantiations
     * The rest are mine, Taking Random value for Position X {-1,0,1} and Incrementing the Z with i to avoid collision too
     * Zpos for the Platform to instantiate in the right position
     */
    public void CreateTiles()
    {


        randonNumber = UnityEngine.Random.Range(0, 10);

        if (randonNumber <= 3)
        {
            for (int i = 0; i < 4; i++)
            {
                randx = UnityEngine.Random.Range(-1, 2);
                Instantiate(coinObj, new Vector3(randx, 0.25f, zPos + i), coinObj.rotation);
            }

        }

        if (randonNumber >= 5)
        {
            for (int i = 0; i < 2; i++)
            {
                randx = UnityEngine.Random.Range(-1, 2);
                if (randx == 1)
                {
                    Instantiate(obstObj, new Vector3(randx - i, 0.5f, zPos + randx), obstObj.rotation);
                    Instantiate(coinObj, new Vector3(randx - 1, 0.25f, zPos + i * 4), coinObj.rotation);
                }

                if (randx == -1)
                {
                    Instantiate(obstObj, new Vector3(randx + i, 0.5f, zPos + randx), obstObj.rotation);
                    Instantiate(coinObj, new Vector3(randx + i, 0.25f, zPos + i * 4), coinObj.rotation);
                }

                else
                    Instantiate(obstObj, new Vector3(1, 0.5f, zPos + randx), obstObj.rotation);
            }

        }
        if (randonNumber == 4)
        {
            Instantiate(capsuleObj, new Vector3(randx, 0.25f, zPos), capsuleObj.rotation);
        }
        Instantiate(platform, new Vector3(0, 0, zPos), platform.rotation);
        zPos += 6;

    }


}

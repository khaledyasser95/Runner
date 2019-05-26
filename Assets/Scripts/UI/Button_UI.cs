using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button_UI : MonoBehaviour
{
    void Start()
    {
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(delegate () { StartGame("RUN"); });
       
    }
    //Reset the values
    public void StartGame(string run)
    {
        GameMaster.dead = false;
        GameMaster.coinTotal = 0;
        GameMaster.timeTotal = 0;
        SceneManager.LoadScene(run);
    }

}

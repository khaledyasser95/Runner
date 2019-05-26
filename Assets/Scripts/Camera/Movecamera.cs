using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecamera : MonoBehaviour
{
    public GameObject player;
    public float zOffset = -3f;

    // Update is called once per frame
    void Update()
    {

        try
        {
            Vector3 pos = player.transform.position;
            pos.z += zOffset;
            pos.y = 3;
            transform.position = pos;
        }
        catch
        {
            Application.Quit();

        }

    }
}

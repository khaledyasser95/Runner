using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField]
    private int Speed = 6;
    Control control;
    private void Awake()
    {
        control = GetComponent<Control>();
    }

    // Update is called once per frame
    void Update()
    {
        control.Swipe();
        control.Keyboard();
      
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(control.get_HorizVal() * 2.5f, 0, Speed);
    }


    private void OnDestroy()
    {
        GameMaster.dead = true;
    }

   
}

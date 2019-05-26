using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{

    // Rotating the Capsule and coin , simple and cool effect
    void Update()
    {
        if (gameObject.tag == "Capsule")
            transform.Rotate(3, 0, 0);
        if (gameObject.tag == "coin")
            transform.Rotate(0, 0, 3);
    }
}

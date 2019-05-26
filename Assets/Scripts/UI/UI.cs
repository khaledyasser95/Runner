using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    void Update()
    {
        if (gameObject.name == "coinTotal")
            GetComponent<TextMesh>().text = "Coins: " + GameMaster.coinTotal;

        if (gameObject.name == "coinsvalue")
            GetComponent<Text>().text = GameMaster.coinTotal.ToString();

        if (gameObject.name == "timevalue")
            GetComponent<Text>().text = GameMaster.timeTotal.ToString();
    }
   

}

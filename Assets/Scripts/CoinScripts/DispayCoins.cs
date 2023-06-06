using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayCoins : MonoBehaviour
{
    public static int coinCount;
    public GameObject coinCountDisplay;

    void Update()
    {
        coinCountDisplay.GetComponent<Text>().text = "" + coinCount;
    }
}

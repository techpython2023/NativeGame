using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunCount : MonoBehaviour
{
    public GameObject disDisplay;
    public int disRun = 0;
    public bool addingDis = false;
    public float delay = 0.25f;

    void Update()
    {
        if (addingDis == false)
        {
            addingDis = true;
            StartCoroutine(AddingDist());
        }
        
    }
    IEnumerator AddingDist()
    {
        disRun += 1;
        disDisplay.GetComponent<Text>().text = "" + disRun;
        yield return new WaitForSeconds(delay);
        addingDis = false;
    }

}

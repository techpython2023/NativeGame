using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject Player;
    public GameObject Cop;
    public GameObject CopModel;
    public GameObject CharacterModel;
    public float kickDelay;
    public float fallDelay;

    void Start()
    {
        Cop.GetComponent<CapsuleCollider>().enabled = false;
        Player.GetComponent<CapsuleCollider>().enabled = false;
    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
       this.gameObject.GetComponent<BoxCollider>().enabled = false;
 
        Player.GetComponent<AbbieCharacterController>().enabled = false;
        Cop.GetComponent<CopCharacterController>().enabled = false;
        StartCoroutine(CollisionDelay());

    }
    IEnumerator CollisionDelay()
    {
        yield return new WaitForSeconds(fallDelay);
        CharacterModel.GetComponent<Animator>().Play("Stumble Backwards");
        yield return new WaitForSeconds(kickDelay);
        CopModel.GetComponent<Animator>().Play("Mma Kick");
    }


}

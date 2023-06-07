using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject Cop;
    public GameObject CopModel;
    public GameObject CharacterModel;
    public float kickDelay;
    public float fallDelay;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;

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

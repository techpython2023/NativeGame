using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //Referance to the caracter Controller
    private CharacterController controller;
    private Vector3 direction;
    public float fowardSpeed;
    //0-left 1-middle 2-right
    private int desiredLane = 1;
    //Distance between 2 lanes
    public float laneDistance = 4;

    public float jumpForce;

    public float gravity = -20;
    // Start is called before the first frame update
    void Start()
    {
        //Get component off character
        controller = GetComponent<CharacterController>();
     
    }

    // Update is called once per frame
    void Update()
    {
        
        //Move player forwad 
        direction.z = fowardSpeed;
        if(controller.isGrounded)
        {
            direction.y = -1;
          if(Input.GetKeyDown(KeyCode.UpArrow))
           {
            jump();
           }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }
        //Gather user inputs on which lane we shoul be
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
        }
        if(desiredLane == 3)
        {
            desiredLane = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
        }
        if (desiredLane == -1)
        {
            desiredLane = 0;
        }

        //Calculate where we should be using desired lane Arrow
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if(desiredLane==2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        //transform.position = Vector3.Lerp(transform.position,targetPosition,80 * Time.deltaTime);
        //controller.center = controller.center;
        if(transform.position == targetPosition)
        {
            return;
        }
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if(moveDir.sqrMagnitude <diff.sqrMagnitude)
        {
            controller.Move(moveDir);
        }
        else
        {
            controller.Move(diff);
        }
    }

    private void FixedUpdate()
    {
        //Make character to move in vector 3 direction
        //Time.fixedDeltaTime- for speed
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void jump()
    {
        direction.y = jumpForce;
    }
}

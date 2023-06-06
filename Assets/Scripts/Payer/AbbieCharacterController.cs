using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbbieCharacterController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float jumpHeight = 2f;
    float gravity = -60f;
    private CharacterController controller;
    private Vector3 velocity;
    private bool IsGrounded;
    private int desiredLane = 1;
    //Distance between 2 lanes
    public float laneDistance = 3;
    public float jumpForce;
    public bool IsJumping = false;
    public bool comingDown = false;
    public GameObject Player;
    public bool canMove = false;

    private float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    if (IsJumping == false)
        //    {
        //        Player.GetComponent<Animator>().Play("Jump");
        //    }
        //}



        horizontalInput = 1;
        //FaceForward
        transform.forward = new Vector3(0, 0,Mathf.Abs(horizontalInput) -1);
        IsGrounded = Physics.CheckSphere(transform.position,0.1f,groundLayers,QueryTriggerInteraction.Ignore);
        if(IsGrounded && velocity.y<0 )
        {
            velocity.y = 0;
        }
        else
        {

            velocity.y += gravity * Time.deltaTime;
           
        }
        controller.Move(new Vector3(0,0, horizontalInput*runSpeed) *Time.deltaTime);

        //if (canMove)
        //{


            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                desiredLane++;
            }
            if (desiredLane == 3)
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
            if (desiredLane == 0)
            {
                targetPosition += Vector3.left * laneDistance;
            }
            else if (desiredLane == 2)
            {
                targetPosition += Vector3.right * laneDistance;
            }
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            {
                controller.Move(moveDir);
            }
            else
            {
                controller.Move(diff);
            }


            if (IsGrounded && Input.GetButtonDown("Jump"))
            {
                if (IsJumping == false)
                {
                    IsJumping = true;
                    Player.GetComponent<Animator>().Play("Jump");
                    StartCoroutine(JumpSequence());
                }

                //velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
                IsGrounded = false;

            }
        //}
        controller.Move(velocity * Time.deltaTime);

        if (IsJumping==true)
        {
            if(comingDown==false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
            }
            if (comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -3, Space.World);
            }
        }

    }
    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        IsJumping = false;
        comingDown = false;
       
        Player.GetComponent<Animator>().Play("Standard Run");
    }
}

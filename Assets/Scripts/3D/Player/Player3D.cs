using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D : MonoBehaviour
{
    private static Player3D instance;
    public static Player3D Instance
    {
        get
        {
            return instance;
        }
    }

    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool grounded;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        /*if (GroundCheck3D.Instance.onGround && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        */
        float horizInput = Input.GetAxisRaw("Horizontal");
        float vertInput = Input.GetAxisRaw("Vertical");

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        //normalize the movement vector to prevent super fast diagonal movement
        Vector3 movement = Vector3.Normalize(forwardMovement + rightMovement);

        controller.Move(movement * Time.deltaTime * playerSpeed);
        /*
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && GroundCheck3D.Instance.onGround)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        */
    }

    //[Header("Movement")]

    

    //[Header("Jumping")]
    //[SerializeField] private float jumpForce;
    //[SerializeField] private KeyCode jumpKey;
    //private bool isJumping;

    //private CharacterController charController;
    //private Rigidbody rigidBody;

    //private void Awake()
    //{
    //    charController = GetComponent<CharacterController>();
    //    rigidBody = GetComponent<Rigidbody>();
    //}

    //private void Start()
    //{

    //}

    //private void Update()
    //{
    //    PlayerMove();
    //}

    //private void FixedUpdate()
    //{
    //    if (Input.GetKeyDown(jumpKey))
    //    {
    //        isJumping = true;
    //        Debug.Log("Jumping");
    //        rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //    }
    //}

    ////handle player movement with input from the horizontal and vertical axes
    //private void PlayerMove()
    //{
    //    float horizInput = Input.GetAxisRaw(horizontalInputName);
    //    float vertInput = Input.GetAxisRaw(verticalInputName);

    //    Vector3 forwardMovement = transform.forward * vertInput;
    //    Vector3 rightMovement = transform.right * horizInput;

    //    //normalize the movement vector to prevent super fast diagonal movement
    //    Vector3 movement = Vector3.Normalize(forwardMovement + rightMovement) * movementSpeed;

    //    charController.SimpleMove(movement);
    //}


    //jump movement
    //private IEnumerator JumpEvent()
    //{
    //    charController.slopeLimit = 90.0f;
    //    float timeInAir = 0.0f;
    //    do
    //    {
    //        float jumpForce = jumpFallOff.Evaluate(timeInAir);
    //        charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
    //        timeInAir += Time.deltaTime;
    //        yield return null;
    //    } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);
    //    charController.slopeLimit = 45.0f;
    //    isJumping = false;
    //}


}
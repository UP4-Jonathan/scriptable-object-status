using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MoveWithCondition: MonoBehaviour
{ 
    //Refernce to out Character Stat Script
    [SerializeField] private SimpleCharacter character;

    private CharacterController controller;
    private Transform charTransform;
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;

    [SerializeField] private Vector2 moveVector;

    [Header("Move Properties")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    private Vector3 velocity;
    private Vector3 rotation;
    private float rotationSmooth;
    private Vector3 defaultVelocity;
    private float currentSpeed;


    [Header("Ground Checking Properties")]
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private Transform groundCheckObject;
    [SerializeField] private float groundOffset;
    [SerializeField] private LayerMask groundMask;

    [Header("Jump Properties")]
    [SerializeField] private bool startJump = false;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;

    [Header("Dash Properties")]
    private bool isDashing = false;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashPower;
    
    private void Awake() 
    {
        controller = GetComponent<CharacterController>();
        charTransform = transform;
        if(groundCheckObject == null) groundCheckObject = charTransform;
    }

    void Start()
    {
        float y = velocity.y -= gravity *Time.deltaTime;
        defaultVelocity = new Vector3(velocity.x,y,velocity.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(!character.canMove) return;

        isGrounded = CheckGrounded();
        if(isGrounded)
        {
            if(velocity.y < 0f) velocity.y = 0.0f;
            velocity = CalculateMove(moveVector, velocity);
            velocity *= moveSpeed;

            if(startJump)
            {
                velocity.y = jumpForce;
                startJump = false;
            }           
        } 
        else 
        {
            startJump = false;
            velocity.y -= gravity *  Time.deltaTime;
        }
        CalculateRotation(moveVector);
        if(velocity.magnitude >= 0.1f)
        {
            
            controller.Move(velocity * Time.deltaTime);   
        } 
    }

    private bool CheckGrounded()
    {
        return Physics.CheckSphere(groundCheckObject.position, groundOffset,groundMask,QueryTriggerInteraction.Ignore);
    }

    private Vector3 CalculateMove(Vector2 move, Vector3 currentVelocity)
    {
        return  new Vector3(move.x, velocity.y, move.y).normalized;
    }

    private void CalculateRotation(Vector2 inputVector)
    { 
        Vector3 rotation = new Vector3(inputVector.x, 0.0f, inputVector.y);
        if (inputVector != Vector2.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotation), 0.15F);
        }
    }

    public void OnMoveInput(Vector2 inputVector )
    {
       moveVector = inputVector;
    }

    public void OnJumpInput(bool value)
    {
        startJump = value;
    }

    public void OnDashInput(bool value)
    {
        isDashing = value;
    }
}

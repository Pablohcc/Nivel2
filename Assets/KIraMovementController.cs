using UnityEngine;

public class KIraMovementController : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float speed;

    public float turnSmooth = 0.1f;
    public float turnsmoothVelocity;
    public Transform cam;
    public CharacterController Controller;

    public Vector3 velocity;
    public float gravity = -9.81f;

    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;

    public bool IsGrounded;
    public float Hjump;

    public bool IsFall;
    public bool IsJump;
    public bool IsLand;

    public Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Salto();
        Movimiento();
    }

    void Movimiento()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        float Magnitud = Mathf.Clamp01(direction.magnitude);
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Magnitud /= 0.5f;
        }

        animator.SetFloat("InputMagnitude", Magnitud, 0.05f, Time.deltaTime);

        if (direction.magnitude >= 0.1f)
        {
            float TargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref turnSmooth, turnsmoothVelocity);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 MoveDirection = Quaternion.Euler(0f, TargetAngle, 0) * Vector3.forward;
            Controller.Move(MoveDirection * speed * Time.deltaTime);
        }


    }


    void Salto()
    {
        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);
        if (IsGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            animator.SetBool("IsLanding", true);
            IsLand = true;
            animator.SetBool("IsJumping", false);
            IsJump = false;
        }
        else
        {
            animator.SetBool("IsLanding", false);
            IsLand = true;
            if (IsJump && velocity.y < 0)
            {
                animator.SetBool("IsFalling", true);
            }

        }

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            velocity.y = Mathf.Sqrt(Hjump * -2 * gravity);
            animator.SetBool("IsJumping", true);
            IsJump = true;
        }

        velocity.y += gravity * Time.deltaTime;
        Controller.Move(velocity * Time.deltaTime);
    }




}
using UnityEngine;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class KIraMovementController : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float Vertical;
    public float speed;
    public Transform Cam;

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

    public float TurnSmooth = 0.1f;
    public float TurnSmoothVelocity;


    public Animator animator;

    public VidaJugador VidaJugadorScript;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ///Condicional para cuando llegue a 0 de vida el Jugador no se pueda mover
        if (VidaJugadorScript.vidaActual >= 1)
        {
            Salto();
            //MovimientoconControler();
            Movimiento();
        }
        ///En esta condicional se puede agregar una animacion de muerte
		if (VidaJugadorScript.vidaActual <= 0)
        {
            //Destroy(gameObject);
        }
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


    public void MovimientoconControlerTereraPersona()
    {
        horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, Vertical);
        float Magnitud = Mathf.Clamp01(direction.magnitude); ///convierte los numeros entre los rangos 0 y 1
                                                             ///detectar el rango entre 0 y 1.

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Magnitud /= 0.5f;
        }
        animator.SetFloat("InputMagnitude", Magnitud, 0.05f, Time.deltaTime);


        if (direction.magnitude >= 0.1f)
        {
            float TargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;  ///Encontrando el Angulo entre X y Z
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref TurnSmooth, TurnSmoothVelocity);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);  ///Con el Angulo encontrado le digo al player que gire 

            Vector3 MoveDirection = Quaternion.Euler(0f, TargetAngle, 0f) * Vector3.forward;

            Controller.Move(MoveDirection * speed * Time.deltaTime);
        }





    }
}
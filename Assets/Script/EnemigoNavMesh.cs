using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class EnemigoNavMesh : MonoBehaviour
{
	public float RadioMira;
	public Transform PointerPlayer;
	public NavMeshAgent Agent;
	public float RadioDisparo;
	public Animator AnimatorEnemy;

	public GameObject BalaEnemigo;
	public Transform PointerBala;
	public float Tiempo;
	public float TiempoRestante;


	[Header("Configuración de Patrullaje")]
	public Transform pointA;
	public Transform pointB;
	private Transform currentPatrolTarget;

	public float distancia;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()

	{
		PointerPlayer = GameObject.FindGameObjectWithTag("Player").transform;
		AnimatorEnemy = GetComponentInChildren<Animator>();
		Agent = GetComponent<NavMeshAgent>();
		currentPatrolTarget = pointA;
		Agent.SetDestination(currentPatrolTarget.position);
	}

	// Update is called once per frame
	void Update()
	{
		//MovimientoNaveMesh();
		distancia = Vector3.Distance(PointerPlayer.position, transform.position);
		
		if (distancia <= RadioMira)
		{
			MovimientoNaveMesh(distancia);
		} else {
			Patrol();
		}


	}

	void MovimientoNaveMesh(float distance)
	{
		FaceTarget();
		//float distancia = Vector3.Distance(PointerPlayer.position, transform.position);
		//Debug.Log(distancia);

		if (distancia <= RadioMira)
		{
			//Debug.Log("Segui al Player");
			Agent.SetDestination(PointerPlayer.position);
			AnimatorEnemy.SetBool("Run", true);
			Agent.speed = 10f;



			if (distancia <= RadioDisparo)
			{
				//EnemigoAnimator.SetBool("Run", false);
				AnimatorEnemy.SetBool("Disparar", true);
				Agent.speed = 0f;
				//GenerarBala();
			}
			else
			{
				AnimatorEnemy.SetBool("Disparar", false);
			}
		}
		else
		{
			AnimatorEnemy.SetBool("Run", false);
			Agent.speed = 0f;
		}
	}

	private void Patrol()
	{
		Agent.SetDestination(currentPatrolTarget.position);
		AnimatorEnemy.SetBool("Disparar", false);
		Agent.speed = 10f;
		Agent.acceleration = 8;

		if (!Agent.pathPending && Agent.remainingDistance < 0.5f)
		{
			currentPatrolTarget = currentPatrolTarget == pointA ? pointB : pointA;
		}
	}


	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, RadioMira);



		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, RadioDisparo);
	}

	void FaceTarget()
	{
		Vector3 direction = (PointerPlayer.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 1f);

	}

	public void GenerarBala()
	{

		TiempoRestante = TiempoRestante - Time.deltaTime;
		if (TiempoRestante <= 0)
		{
			Instantiate(BalaEnemigo, PointerBala.transform.position, PointerBala.transform.rotation);
			TiempoRestante = Tiempo;
		}

	}
}

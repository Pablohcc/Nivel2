using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshIA : MonoBehaviour
{
	[Header("Configuración de Patrullaje")]
	public Transform pointA;
	public Transform pointB;
	private Transform currentPatrolTarget;

	[Header("Configuración de Persecución")]
	public Transform player;
	public float detectionRadius = 10f;

	[Header("Configuración de Disparo")]
	public float shootingRadius = 5f; // Debe ser menor que detectionRadius
	public float fireRate = 1f; // Tiempo en segundos entre cada disparo
	public GameObject projectilePrefab; // El prefab de la bala
	public Transform firePoint; // Desde dónde sale la bala

	private float nextFireTime;
	private NavMeshAgent agent;

	public Animator AnimatorEnemy;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		AnimatorEnemy = GetComponentInChildren<Animator>();
		agent = GetComponent<NavMeshAgent>();
		currentPatrolTarget = pointA;
		agent.SetDestination(currentPatrolTarget.position);
	}

	void Update()
	{
		float distanceToPlayer = Vector3.Distance(transform.position, player.position);

		// 1. Si el jugador está en rango de disparo
		if (distanceToPlayer <= shootingRadius)
		{
			agent.isStopped = true; // Detenemos al enemigo para que dispare firme
			FacePlayer(); // Hacemos que mire hacia el jugador
			//Shoot();
		}
		// 2. Si el jugador está en rango de persecución pero no de disparo
		else if (distanceToPlayer <= detectionRadius)
		{
			agent.isStopped = false; // Permitimos que vuelva a moverse
			ChasePlayer();
		}
		// 3. Si el jugador está lejos
		else
		{
			agent.isStopped = false; // Permitimos que vuelva a moverse
			Patrol();
		}
	}

	private void Patrol()
	{
		agent.SetDestination(currentPatrolTarget.position);
		AnimatorEnemy.SetBool("Disparar", false);
		agent.speed = 10f;
		agent.acceleration = 8;

		if (!agent.pathPending && agent.remainingDistance < 0.5f)
		{
			currentPatrolTarget = currentPatrolTarget == pointA ? pointB : pointA;
		}
	}

	private void ChasePlayer()
	{
		agent.speed = 10f;
		agent.acceleration = 8;
		AnimatorEnemy.SetBool("Disparar", false);
		agent.SetDestination(player.position);
	}

	private void Shoot()
	{
		// Comprobamos si ya pasó el tiempo necesario para el siguiente disparo
		if (Time.time >= nextFireTime)
		{
			// Creamos la bala en la posición y rotación del firePoint
			Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

			// Calculamos cuándo será el próximo disparo
			nextFireTime = Time.time + fireRate;
		}
	}
	

	private void FacePlayer()
	{
		// Calculamos la dirección hacia el jugador (ignorando el eje Y para que el enemigo no se incline)
		Vector3 direction = (player.position - transform.position).normalized;
		direction.y = 0;

		// Rotamos suavemente hacia el jugador
		//Quaternion lookRotation = Quaternion.LookRotation(direction);
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

		agent.speed = 0f;
		agent.acceleration = 120;
		AnimatorEnemy.SetBool("Disparar", true);
	}

	// Dibujamos las esferas en el editor para ver los radios
	private void OnDrawGizmosSelected()
	{
		// Radio de persecución en Rojo
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, detectionRadius);

		// Radio de disparo en Amarillo
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, shootingRadius);
	}
}
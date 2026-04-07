using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
	public float RadioMira;
	public Transform PointerPlayer;
	public NavMeshAgent Agent;
	public float RadioDisparo;
	public Animator AnimatorEnemy;
	public Transform PointerA;
	public Transform PointerB;
	public float RadioA;
	public float RadioB;
	public float distancia;
	public float distanciaB;
	public bool Entrar;
	public GameObject Player;
	public bool RadioABool;
	public bool RadioBBool;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()

	{
		AnimatorEnemy = GetComponentInChildren<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		distancia = Vector3.Distance(PointerPlayer.position, transform.position);
		//distanciaB = Vector3.Distance(PointerA.position, transform.position);


		if (distancia <= RadioMira && Entrar == true)
		{
			MovimientoNaveMesh();
		}
		else
		{
			MovimientoAB();
		}




		//MovimientoAB();
		//MovimientoNaveMesh();
	}


	public void OnTriggerStay(Collider other)
	{
		if (other.transform.tag == "PointerA")
		{
			RadioABool = true;
		}

		if (other.transform.tag == "PointerB")
		{
			RadioABool = false;
		}
	}






	void MovimientoNaveMesh()
	{
		FaceTarget();
		distancia = Vector3.Distance(PointerPlayer.position, transform.position);
		Debug.Log(distancia);
		///Transform PoninterPlayer2 = PointerPlayer.position

		if (distancia <= RadioMira)
		{
			//Debug.Log("Segui al Player");
			Agent.SetDestination(PointerPlayer.position);
			AnimatorEnemy.SetBool("Atacar", false);
			Agent.speed = 10f;
			Agent.acceleration = 8;



			if (distancia <= RadioDisparo)
			{
				//EnemigoAnimator.SetBool("Run", false);
				AnimatorEnemy.SetBool("Atacar", true);
				Agent.speed = 0f;
				Agent.acceleration = 120;
				//Agent.isStopped = true;
			}
			/* else
			{
				AnimatorEnemy.SetBool("Atacar", false);
			}*/
		}
		else
		{
			AnimatorEnemy.SetBool("Atacar", false);
			Agent.speed = 10f;
			Agent.acceleration = 8;
		}
	}


	



	void MovimientoAB()
	{
		distanciaB = Vector3.Distance(PointerA.position, transform.position);

		if (distanciaB <= RadioA && RadioABool == true)
		{
			Agent.angularSpeed = 300f;
			FaceTargetB();
			Agent.SetDestination(PointerB.position);
			//AnimatorEnemy.SetBool("Atacar", false);
			Agent.speed = 10f;
			

		}
		if (distanciaB >= RadioB && RadioABool==false)
		{
			Agent.angularSpeed = 300f;
			FaceTargetA();
			Agent.SetDestination(PointerA.position);
			Agent.speed = 10f;
		

		}

	}




	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, RadioMira);



		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, RadioDisparo);


		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere(transform.position, RadioA);
	}

	void FaceTarget()
	{
		Vector3 direction = (PointerPlayer.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 1f);

	}

	void FaceTargetA()
	{
		Vector3 directionAA = (PointerA.position - transform.position).normalized;
		Quaternion lookRotationA = Quaternion.LookRotation(new Vector3(directionAA.x, 0, directionAA.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotationA, 0f);

	}

	void FaceTargetB()
	{
		Vector3 directionBB = (PointerB.position - transform.position).normalized;
		Quaternion lookRotationB = Quaternion.LookRotation(new Vector3(directionBB.x, 0, directionBB.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotationB, 0f);

	}

	public void Entrada()
	{
		Entrar = true;
	}

}

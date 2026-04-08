using UnityEngine;

public class ExplosionRetroceso : MonoBehaviour
{
	public float radius;
	public float FuerzaExplosion;
	public float delay;
	public bool Hola;

	//public GameObject ParticulaExplosion;
	//public GameObject[] Objetos;
	//public Collider[] collision;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		Invoke("ExplosionGranada", delay);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ExplosionGranada()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

		foreach (Collider ObjConCollider in colliders)
		{
			Rigidbody rb = ObjConCollider.GetComponent<Rigidbody>();

			if (rb != null)
			{
				rb.AddExplosionForce(FuerzaExplosion, transform.position, radius, 1f, ForceMode.Impulse);
			}
			//Instantiate(ParticulaExplosion, transform.position, transform.rotation);
			//Destroy(gameObject, 2f);
		}
		foreach (Collider col in colliders)
		{
			if (col.CompareTag("Player"))
			{
				Debug.Log("Enemigo Detectado");
				//col.GetComponent<EnemyHealth>()?.TakeDamage(10);
			}

		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, radius);
	}


}

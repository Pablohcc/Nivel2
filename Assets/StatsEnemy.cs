using UnityEngine;

public class StatsEnemy : MonoBehaviour
{
    public Transform PointerBala;
    public Transform jugador;
    public GameObject Bala;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //DispararBala();
    }

    public void InstanciaBala()
    {
        Instantiate(Bala, PointerBala.transform.position, PointerBala.transform.rotation);


	}
	/*
	void DispararBala()
	{
		// 1. Instanciar la bala en la posición y rotación del punto de disparo
		GameObject bala = Instantiate(Bala, PointerBala.position, PointerBala.rotation);

		// 2. Calcular la dirección hacia el jugador
		Vector3 direccion = (jugador.position - PointerBala.position).normalized;

		// 3. Obtener el componente Rigidbody de la bala y empujarla
		Rigidbody rbBala = bala.GetComponent<Rigidbody>();
		if (rbBala != null)
		{
			rbBala.linearVelocity = direccion * 15f; // Cambia 15f por la velocidad que necesites
		}
	}
	*/
}


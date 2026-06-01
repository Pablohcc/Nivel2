using System.Collections;
using UnityEngine;

public class RocaIMov : MonoBehaviour
{
    [Header("Puntos de Ruta")]
	public Transform puntoA;
	public Transform puntoB;

	[Header("Configuración de Velocidad")]
	public float velocidadMinima = 1f;
	public float velocidadMaxima = 5f;
	public float intervaloDeCambio = 2f; // Tiempo en segundos para cambiar la velocidad

	private float velocidadActual;
	private Transform objetivoActual;

	void Start()
	{
		// Iniciamos yendo hacia el Punto B
		objetivoActual = puntoB;

		// Asignamos una velocidad inicial
		CambiarVelocidad();

		// Iniciamos la rutina que cambiará la velocidad cada cierto tiempo
		StartCoroutine(RutinaCambioVelocidad());
	}

	void Update()
	{
		// 1. Mover el objeto hacia el objetivo actual
		transform.position = Vector3.MoveTowards(transform.position, objetivoActual.position, velocidadActual * Time.deltaTime);

		// 2. Comprobar si hemos llegado al objetivo actual (con un pequeño margen de error)
		if (Vector3.Distance(transform.position, objetivoActual.position) < 0.01f)
		{
			// Cambiar la dirección
			if (objetivoActual == puntoA)
			{
				objetivoActual = puntoB;
			}
			else
			{
				objetivoActual = puntoA;
			}
		}
	}

	// Método para calcular una nueva velocidad
	private void CambiarVelocidad()
	{
		velocidadActual = UnityEngine.Random.Range(velocidadMinima, velocidadMaxima);
	}

	// Corrutina que se ejecuta en bucle esperando el tiempo indicado
	IEnumerator RutinaCambioVelocidad()
	{
		while (true) // Bucle infinito que durará mientras el objeto exista
		{
			yield return new WaitForSeconds(intervaloDeCambio);
			CambiarVelocidad();
		}
	}
}
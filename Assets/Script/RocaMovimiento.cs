using System.Collections;
using UnityEngine;

public class RocaMovimiento : MonoBehaviour
{
	public Transform puntoA;
	public Transform puntoB;
	public float velocidad = 2.0f;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		StartCoroutine(VelocidadTransfomr());
	}

    // Update is called once per frame
    void Update()
    {
		
		

		// Mathf.PingPong alterna un valor entre 0 y la duración
		// Usamos Time.time para el tiempo continuo
		float tiempo = Mathf.PingPong(Time.time * velocidad, 1.0f);

		// Vector3.Lerp interpola entre A y B basándose en el valor de tiempo (0 a 1)
		transform.position = Vector3.Lerp(puntoA.position, puntoB.position, tiempo);
		
	}

	IEnumerator VelocidadTransfomr ( ) {
		
		yield return new WaitForSeconds(3f);
		velocidad = UnityEngine.Random.Range(1, 4);
	}
}

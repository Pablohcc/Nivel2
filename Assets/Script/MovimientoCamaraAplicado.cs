using System.Collections;
using UnityEngine;

public class MovimientoCamaraAplicado : MonoBehaviour
{
	public float RandomNumero = 3;
	public float timer = 4;

	[Header("Instancia la Roca")]
	public Transform RocaPosicion;
	public Transform RocaPosicion2;
	public Transform RocaPosicion3;
	public Transform RocaPosicion4;
	public Transform RocaPosicion5;
	public Transform RocaPosicion6;
	public Transform RocaPosicion7;
	public Transform RocaPosicion8;
	public Transform RocaPosicion9;
	public Transform RocaPosicion10;
	public Transform RocaPosicion11;
	public Transform RocaPosicion12;
	public Transform RocaPosicion13;
	public Transform RocaPosicion14;
	public Transform RocaPosicion15;
	public Transform RocaPosicion16;

	[Header("Objeto o Prefab de Roca")]
	public GameObject InstanciaRoca;
	//public GameObject InstanciaRoca2;
	//public GameObject InstanciaRoca3;
	
	public void OnTriggerStay(Collider other)
	{
		if (other.transform.CompareTag("Player")){
			//CineMachibeMovimientoCamara.Instance.MoverCamara(5, 5, 2); /// el ultimo numero es para ver cuanto tiempo dura
			timer -= Time.deltaTime;
			//RandomNumero = UnityEngine.Random.Range(0f, 6f);
			//Debug.Log(RandomNumero);

			//StartCoroutine(TembloresCamaraCorrutina());

			if (timer <= 0f)
			{
				RandomNumero = UnityEngine.Random.Range(0, 10);
				Debug.Log(RandomNumero);
				StartCoroutine(TembloresCamaraCorrutina(RandomNumero));
				
				//StartCoroutine(TembloresCamaraCorrutina());
			}

			if (timer <= -1f)
			{
				RocaInstanciada();
			}

			if (timer <= -1f)
			{
				timer = 5f;
			}

			//StartCoroutine(TembloresCamaraCorrutina(RandomNumero));

			//Debug.Log(RandomNumero);

		}
	}

	IEnumerator TembloresCamaraCorrutina(float random){
		CineMachibeMovimientoCamara.Instance.MoverCamara(5, 5, 1);
		//Instantiate(InstanciaRoca, RocaPosicion.transform.position, RocaPosicion.transform.rotation);
		//InvokeRepeating("RocaInstanciada",2, 3);
		yield return new WaitForSeconds(random);
		

	}

	public void RocaInstanciada()
	{
		Quaternion rotacionAleatoria = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
		Instantiate(InstanciaRoca, RocaPosicion.transform.position, rotacionAleatoria);
		Instantiate(InstanciaRoca, RocaPosicion2.transform.position, rotacionAleatoria);
		Instantiate(InstanciaRoca, RocaPosicion3.transform.position, rotacionAleatoria);
		Instantiate(InstanciaRoca, RocaPosicion4.transform.position, rotacionAleatoria);
		Instantiate(InstanciaRoca, RocaPosicion5.transform.position, rotacionAleatoria);
		Instantiate(InstanciaRoca, RocaPosicion6.transform.position, rotacionAleatoria);
		Instantiate(InstanciaRoca, RocaPosicion7.transform.position, rotacionAleatoria);
		Instantiate(InstanciaRoca, RocaPosicion8.transform.position, rotacionAleatoria);
		Instantiate(InstanciaRoca, RocaPosicion9.transform.position, rotacionAleatoria);
		Instantiate(InstanciaRoca, RocaPosicion10.transform.position, rotacionAleatoria);
		Instantiate(InstanciaRoca, RocaPosicion11.transform.position, rotacionAleatoria);
		Instantiate(InstanciaRoca, RocaPosicion12.transform.position, rotacionAleatoria);
		Instantiate(InstanciaRoca, RocaPosicion13.transform.position, rotacionAleatoria);
		Instantiate(InstanciaRoca, RocaPosicion14.transform.position, rotacionAleatoria);
		Instantiate(InstanciaRoca, RocaPosicion15.transform.position, rotacionAleatoria);
		Instantiate(InstanciaRoca, RocaPosicion16.transform.position, rotacionAleatoria);
		//Instantiate(InstanciaRoca, RocaPosicion.transform.position, RocaPosicion.transform.rotation);
	}

}

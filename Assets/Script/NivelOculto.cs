using UnityEngine;
using UnityEngine.SceneManagement;

public class NivelOculto : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	public void OnTriggerEnter(Collider other)
	{
		if(other.transform.CompareTag("Player"))
		{
			SceneManager.LoadScene("Nivel2lvloculto");
			
		}
	}
}

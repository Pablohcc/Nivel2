using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EventPlayer : MonoBehaviour
{
	public UnityEvent TriggerEnter;
    public UnityEvent TriggerExit;

	// Start is called once before the first execution of Update after the MonoBehaviour is created


	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			TriggerEnter.Invoke();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			TriggerExit.Invoke();
		}
	}
}
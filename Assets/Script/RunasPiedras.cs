using UnityEngine;

public class RunasPiedras : MonoBehaviour
{
    public Animator Piedra1;
    public Animator Piedra2;
    public GameObject Aura;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnTriggerStay(Collider other)
	{
        if (other.transform.CompareTag("Player") && Input.GetKeyDown(KeyCode.Q))
		{
            Aura.SetActive(true);
            Piedra1.SetBool("DetenerRoca1", true);
            Piedra2.SetBool("DetenerRoca2", true);
		}
	}
}

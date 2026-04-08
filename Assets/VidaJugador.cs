using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaActual;
    public float puntos;

    public float cronometro = 3;
    void Start()
    {
        vidaActual = vidaMaxima;

        

	}

	void Update()
	{
		   Cronometro();

		if (vidaActual >= 50 && vidaActual <=99 && cronometro<= -0.09f)
		{
			RecuperacionVida();
		}
		else
		{
			VidaMaximaObtenida();
		}
		
       
	}

	public void RecibirDanio(int cantidad)
    {
        vidaActual -= cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);

        Debug.Log("Vida del jugador: " + vidaActual + "/" + vidaMaxima);

        if (vidaActual <= 0) Morir();
    }

    public void Curar(int cantidad)
    {
        vidaActual += cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);
    }

    void Morir()
    {
        Debug.Log("Game Over");
        // UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Muerte")
        {
            vidaActual = vidaActual - 2000;
            if (vidaActual == 0)
            {
                Morir();
            }
        }
        if (collision.transform.tag == "COIN")
        {
            puntos = puntos + 1;
            Destroy(collision.transform.gameObject);
        }
		/*if (collision.transform.tag == "TRAMPAS")
        {
            vidaActual = vidaActual - 10;
            Debug.Log("Estás perdiendo vida");

        }
        */

		if (collision.transform.tag=="Lava")
		{
            vidaActual = 0;
            Destroy(gameObject);
		}

	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag== "TRAMPAS")
		{
            vidaActual = vidaActual - 15;
		}

		if (other.transform.tag=="Lava")
		{
            vidaActual = 0;
            //Destroy (gameObject);
		}
	}


	///Cronometro para que cada 5 segundos se recupere 1 punto de vida
	public void Cronometro()
    {
        cronometro = cronometro - Time.deltaTime;

		if (cronometro <= -0.1f)
		{
            cronometro = 3f;
		}
	}


    ///Funcion de Recuperación de Vida
    public void RecuperacionVida()
    {
		
            vidaActual = vidaActual + 1;
		
	}


    ///Esta Funcion es para que cuando la vida llega a 100, no se pase de alli
    public void VidaMaximaObtenida()
    {
		if (vidaActual >= vidaMaxima)
		{
            vidaActual = vidaMaxima;
		}

	}

    
}

using UnityEngine;

public class DronHealth : MonoBehaviour
{
    public int vida = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}

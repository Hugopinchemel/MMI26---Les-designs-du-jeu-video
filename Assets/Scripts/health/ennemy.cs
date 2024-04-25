using UnityEngine;

public class Ennemy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>(); 
            playerHealth.TakeDamage(1);
        }
        
    }
}
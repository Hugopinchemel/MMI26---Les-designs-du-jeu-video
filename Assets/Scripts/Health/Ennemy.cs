
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
   {
    if (collision.transform.CompareTag("Player"))
    {
          PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>(); 
          playerHealth.TakeDamage(1);
         }
        
}
}

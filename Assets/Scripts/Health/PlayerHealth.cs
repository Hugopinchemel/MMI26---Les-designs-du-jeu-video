using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public HealthBar healthBar;
    public HUD hud;
    private Vector3 startPosition; // Variable pour stocker la position de départ du joueur
    private int deathCount = 0;
   
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        startPosition = transform.position; // On enregistre la position de départ du joueur
        hud = GameObject.FindObjectOfType<HUD>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(1);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Die()
    {
        Debug.Log("Player died");
        Respawn(); // On fait ressusciter le joueur après sa mort
    }

    public void Respawn()
    {
        deathCount++;
        hud.updateDeathText(deathCount);
        currentHealth = maxHealth; // On réinitialise la santé du joueur à maxHealth
        healthBar.SetHealth(currentHealth); // On met à jour la barre de santé
        transform.position = startPosition; // On fait réapparaître le joueur à sa position de départ
        Debug.Log("Player respawned");
    }
}
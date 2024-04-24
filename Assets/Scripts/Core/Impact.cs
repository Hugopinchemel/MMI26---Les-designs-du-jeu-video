using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{
    [SerializeField] private TableauReinit tableauReinit = null;
    
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            PlayerHealth playerHealth = col.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(1); // On inflige des dégâts au joueur

            if (playerHealth.currentHealth <= 0) {
                // On augmente de 1 le compteur de morts
                col.gameObject.GetComponent<PlayerManager>().AddDeath(); // On récupère le PlayerManager du joueur pour ajouter la mort
            }

            if(tableauReinit != null){
                tableauReinit.Reinit();
            }

            col.gameObject.transform.position = TableauManager.GetCheckpointPosition();
            PlayerManager.SetFreeze(0.5f);
        }
    }
}
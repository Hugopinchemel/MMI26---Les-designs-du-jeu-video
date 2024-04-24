using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float x; // Coordonnée x de la destination du téléporteur
    public float y; // Coordonnée y de la destination du téléporteur
    public int numTableau; // Indice du tableau à afficher après le téléport

    // Définit la position de destination du téléporteur
    public void SetPosition(float _x, float _y)
    {
        x = _x;
        y = _y;
    }

    // Définit l'indice du tableau à afficher après le téléport
    public void SetNumTableau(int _num)
    {
        numTableau = _num;
    }

    // Appelée lorsque le joueur entre en collision avec le téléporteur
    void OnTriggerEnter2D(Collider2D col)
    {
        // Vérifie si le joueur entre en collision avec le téléporteur
        if (col.gameObject.CompareTag("Player"))
        {
            // Récupère le PlayerManager du joueur pour le téléporter
            PlayerManager playerManager = col.gameObject.GetComponent<PlayerManager>();
            if (playerManager != null)
            {
                // Téléporte le joueur à la position spécifiée
                playerManager.Teleport(x, y, numTableau);

                // Affiche le nouveau tableau spécifié
                TableauManager.ShowTableau(numTableau);

                // Met à jour les coordonnées du checkpoint
                TableauManager.UpdateCheckpointPosition(x, y);
            }
            else
            {
                Debug.LogError("PlayerManager not found on the player object!");
            }
        }
    }
}

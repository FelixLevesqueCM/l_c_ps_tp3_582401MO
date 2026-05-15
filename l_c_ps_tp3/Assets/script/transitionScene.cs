using UnityEngine;
using UnityEngine.SceneManagement; // Requis pour la gestion des scènes

public class TeleportationCube : MonoBehaviour
{
    // Se déclenche quand un objet entre dans la zone du Collider
    private void OnTriggerEnter(Collider other)
    {
        // On vérifie si l'objet qui touche le cube possède le tag "Player"
        if (other.CompareTag("Player"))
        {
            // Charge la scène nommée exactement "niveau_2"
            SceneManager.LoadScene("niveau_2");
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlatformCollision : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private Transform platformParent;
    [SerializeField] private bool debugLog = false;

    // Variables ajoutées pour gérer le joueur VR (Character Controller)
    private CharacterController playerController;
    private Vector3 dernierePositionPlateforme;
    private bool joueurSurPlateforme = false;

    private void OnValidate()
    {
        // Ton excellente vérification automatique du trigger dans l'éditeur
        var col = GetComponent<Collider>();
        if (col != null && !col.isTrigger)
        {
            col.isTrigger = true;
            if (debugLog)
            {
                Debug.LogWarning($"{name} : Collider détecté — isTrigger activé automatiquement.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (debugLog)
        {
            Debug.Log($"OnTriggerEnter détecté avec : {other.name}");
        }

        if (!other.CompareTag(playerTag)) return;

        if (platformParent == null)
        {
            if (debugLog) Debug.LogWarning($"PlatformCollision ({name}) : platformParent non assigné.");
            return;
        }

        // 1. On cherche si le joueur a un Character Controller (comme ton XR Origin)
        playerController = other.GetComponent<CharacterController>();

        if (playerController != null)
        {
            joueurSurPlateforme = true;
            dernierePositionPlateforme = platformParent.position;

            if (debugLog) Debug.Log("Joueur VR attaché via CharacterController.");
        }
        else
        {
            // Plan de secours : Si c'est un objet normal, on garde ton ancienne méthode SetParent
            other.transform.SetParent(platformParent, true);
            if (debugLog) Debug.Log("Joueur classique attaché via SetParent.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

        // 2. Le joueur quitte la zone, on réinitialise tout
        joueurSurPlateforme = false;

        if (playerController != null)
        {
            playerController = null;
            if (debugLog) Debug.Log("Joueur VR détaché.");
        }
        else
        {
            other.transform.SetParent(null, true);
            if (debugLog) Debug.Log("Joueur classique détaché (SetParent null).");
        }
    }

    // 3. LateUpdate s'assure que le joueur bouge juste APRES la plateforme
    private void LateUpdate()
    {
        if (joueurSurPlateforme && playerController != null)
        {
            // On calcule la distance que la plateforme vient de parcourir
            Vector3 deplacement = platformParent.position - dernierePositionPlateforme;

            // On applique ce même déplacement au joueur
            playerController.Move(deplacement);

            // On enregistre la nouvelle position pour la prochaine frame
            dernierePositionPlateforme = platformParent.position;
        }
    }
}
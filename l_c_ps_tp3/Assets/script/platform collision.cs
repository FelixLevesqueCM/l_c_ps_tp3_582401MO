using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlatformCollision : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private Transform platformParent;
    [SerializeField] private bool preserveWorldPosition = true;
    [SerializeField] private bool debugLog = false;

    private void OnValidate()
    {
        // Si le GameObject a un Collider, on s'assure qu'il est en trigger dans l'éditeur
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

        if (!other.CompareTag(playerTag))
        {
            return;
        }

        if (platformParent == null)
        {
            if (debugLog)
            {
                Debug.LogWarning($"PlatformCollision ({name}) : platformParent non assigné.");
            }

            return;
        }

        // Attacher le joueur à la plateforme (préserver ou non la position mondiale selon le flag)
        other.transform.SetParent(platformParent, preserveWorldPosition);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(playerTag))
        {
            return;
        }

        // Détacher le joueur de la plateforme
        other.transform.SetParent(null, preserveWorldPosition);
    }
}
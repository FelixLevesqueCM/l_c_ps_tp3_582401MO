using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour // Idéalement, on met une majuscule aux noms de classes
{
    [SerializeField] string playerTag = "Player";
    [SerializeField] Transform platform_bouge;

    private void OnTriggerEnter(Collider other)
    {
        // CompareTag est beaucoup plus performant que .tag.Equals()
        if (other.CompareTag(playerTag))
        {
            // SetParent est la méthode recommandée par Unity au lieu de modifier .parent directement
            other.transform.SetParent(platform_bouge);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // On retire le parent quand le joueur quitte la plateforme
            other.transform.SetParent(null);
        }
    }
}
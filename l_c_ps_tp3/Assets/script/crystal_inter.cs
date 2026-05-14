using UnityEngine;

public class crystal_inter : MonoBehaviour
{
    public mur_deplace wallScript; // Drag your wall object here in the Inspector
    public string swordTag = "GameController"; 
    private bool hasBeenHit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenHit && other.CompareTag(swordTag))
        {
            if (wallScript != null)
            {
                hasBeenHit = true; 
                wallScript.BeginDisplacement();
                Debug.Log("Crystal activated: Wall is moving.");
            }
            else
            {
                Debug.LogWarning("Wall Script reference is missing on " + gameObject.name);
            }
        }
    }
}
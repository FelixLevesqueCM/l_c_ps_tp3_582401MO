using UnityEngine;

public class CrystalInteraction : MonoBehaviour
{
    [Header("Réglages du Mur")]
    public GameObject wall;
    public Vector3 targetPosition;
    public float speed = 2f;

    private bool hasBeenHit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon") && !hasBeenHit)
        {
            hasBeenHit = true;
            Debug.Log("Impact confirmé sur le cristal ! Activation du mur.");

            if (TryGetComponent<Renderer>(out Renderer ren))
            {
                ren.material.color = Color.green;
            }
        }
    }

    private void Update()
    {
        if (hasBeenHit && wall != null)
        {
            wall.transform.position = Vector3.MoveTowards(
                wall.transform.position,
                targetPosition,
                speed * Time.deltaTime
            );
        }
    }
}
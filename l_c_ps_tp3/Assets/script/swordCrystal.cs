using UnityEngine;

public class CrystalInteraction : MonoBehaviour
{
    [Header("Réglages du Mur")]
    public GameObject wall;
    [Tooltip("Distance de montée du mur")]
    public float moveDistance = 5f; 
    public float speed = 2f;

    private Vector3 finalTarget; 
    private bool hasBeenHit = false;

    private void Start()
    {
        if (wall != null)
        {
            finalTarget = wall.transform.position + new Vector3(0, moveDistance, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon") && !hasBeenHit)
        {
            hasBeenHit = true;
            Debug.Log("Impact confirmé ! Le mur monte.");

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
                finalTarget,
                speed * Time.deltaTime
            );
        }
    }
}
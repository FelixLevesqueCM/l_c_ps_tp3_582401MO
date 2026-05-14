using UnityEngine;

public class mur_deplace : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("How far the wall moves from its start position")]
    public Vector3 moveOffset = new Vector3(0, -5, 0); 
    public float speed = 2.0f;

    private Vector3 targetPosition;
    private bool shouldMove = false;

    void Start()
    {
        // Set the destination based on the position at the start of the game
        targetPosition = transform.position + moveOffset;
    }

    void Update()
    {
        if (shouldMove)
        {
            // Move toward the target position every frame
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Stop calculating once we've arrived
            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                transform.position = targetPosition; // Snap to exact position
                shouldMove = false;
            }
        }
    }

    public void BeginDisplacement()
    {
        shouldMove = true;
    }
}
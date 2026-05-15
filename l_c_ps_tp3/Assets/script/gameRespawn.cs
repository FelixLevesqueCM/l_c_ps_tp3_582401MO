using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameRespawn : MonoBehaviour
{
    [SerializeField] private float threshold = -10f;
    [SerializeField] private Transform respawnPoint = null;
    [SerializeField] private bool resetVelocity = true;
    [SerializeField] private bool useFixedUpdate = true;
    [SerializeField] private UnityEvent onRespawn = null;

    private Vector3 _initialPosition;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _initialPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!useFixedUpdate)
        {
            CheckAndRespawn();
        }
    }

    private void FixedUpdate()
    {
        if (useFixedUpdate)
        {
            CheckAndRespawn();
        }
    }

    private void CheckAndRespawn()
    {
        if (transform.position.y < threshold)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        Vector3 target = respawnPoint != null ? respawnPoint.position : _initialPosition;
        transform.position = target;

        if (_rigidbody != null && resetVelocity)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            // Si le Rigidbody utilise la physique continue, on peut aussi forcer l'interpolation désactivée/activée selon les besoins.
        }

        onRespawn?.Invoke();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Vector3 gizmoPos = respawnPoint != null ? respawnPoint.position : transform.position;
        Gizmos.DrawWireSphere(gizmoPos, 0.5f);
        Gizmos.DrawLine(gizmoPos, gizmoPos + Vector3.up * 0.5f);
    }
}
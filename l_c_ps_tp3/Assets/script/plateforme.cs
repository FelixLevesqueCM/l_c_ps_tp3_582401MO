using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateforme : MonoBehaviour
{
    [SerializeField] GameObject pointA;
    [SerializeField] GameObject pointB;
    [SerializeField] float speed = 10f;
    [SerializeField] float delay = 1f;
    [SerializeField] GameObject plateforme_bouge;

    private Vector3 targetPosition;
    private bool movingToB = true;

    void Start()
    {
        if (plateforme_bouge == null)
            plateforme_bouge = this.gameObject;

        if (pointA == null || pointB == null)
        {
            Debug.LogError("pointA et/ou pointB non assignés dans l'inspecteur.");
            enabled = false;
            return;
        }

        plateforme_bouge.transform.position = pointA.transform.position;
        movingToB = true;
        targetPosition = pointB.transform.position;
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            while ((targetPosition - plateforme_bouge.transform.position).sqrMagnitude > 0.0001f)
            {
                plateforme_bouge.transform.position = Vector3.MoveTowards(plateforme_bouge.transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }

            // Assure la position exacte
            plateforme_bouge.transform.position = targetPosition;

            // Attente avant de repartir
            yield return new WaitForSeconds(delay);

            // Inverse la cible
            movingToB = !movingToB;
            targetPosition = movingToB ? pointB.transform.position : pointA.transform.position;
        }
    }
}
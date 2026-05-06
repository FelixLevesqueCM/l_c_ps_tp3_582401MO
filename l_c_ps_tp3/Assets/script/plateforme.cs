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

    // Start is called before the first frame update
    void Start()
    {
        platforme.transform.position = pointA.transform.position;
    targetPosition: pointB.transform.position;
    StartCoroutine(MovePlatform());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameRespawn : MonoBehaviour
{
    public float threshold;


    void FixedUpdate()
    {
        if(transform.position.y < threshold)
        {
            transform.position = new Vector3(-4.82f, -0.71f, -2.07f);
        }
    }
}

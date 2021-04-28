using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlyingEnemy : MonoBehaviour
{
    public Rigidbody2D enemyRB;
    public Transform rayOrigin;
    public LayerMask terrainLayer;
    private float raycastDistance = 2f;
    private float flightSpeed = 5f;
    private Collider2D flightPath;



     void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.transform.position, -Vector2.up ,raycastDistance, terrainLayer);

        if (hit.collider != null)
        {
                Debug.Log("Flying Enemy detects " + hit.collider.ToString());

            Fly();
        }
    }

    void Fly()
    {
        enemyRB.velocity = Vector2.up * flightSpeed;
    }


    


}

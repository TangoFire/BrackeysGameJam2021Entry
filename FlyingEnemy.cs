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
    private Transform flightPath;
    private float flightPathRayCastDistance = 5f;
    private bool flyingRight;



     void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        RaycastHit2D flightPathGroundHit = Physics2D.Raycast(flightPath.position, Vector2.down, flightPathRayCastDistance, terrainLayer);

        if (flightPathGroundHit)
        {
            enemyRB.velocity = Vector2.right * flightSpeed/2;
            bool flyingRight = true;
        }



        RaycastHit2D groundHit = Physics2D.Raycast(rayOrigin.transform.position, -Vector2.up ,raycastDistance, terrainLayer);

        if (groundHit.collider != null)
        {
                Debug.Log("Flying Enemy detects " + groundHit.collider.ToString());

            Fly();
        }
    }

    void Fly()
    {
        enemyRB.velocity = Vector2.up * flightSpeed;
    }


    


}

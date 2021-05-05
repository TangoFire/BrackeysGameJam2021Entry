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
    private float flightLift = 20f;
    public Transform flightPath;
    private float flightPathRayCastDistance = 5f;
    private bool flyingRight = true;



     void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Debug.Log(flightSpeed);
        //enemyRB.AddForce(Vector3.right * flightSpeed);

        enemyRB.velocity = new Vector2(flightSpeed, 0);

        RaycastHit2D flightPathGroundHit = Physics2D.Raycast(flightPath.position, Vector2.down, flightPathRayCastDistance, terrainLayer);

        if (flightPathGroundHit.collider == null)
        {
            if (flyingRight)
            {
                
                Debug.Log("Flying enemy is at right edge");
                flyingRight = false;
                flightSpeed = -5f;
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
            

           

           
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
        enemyRB.AddForce(Vector2.up*flightLift);
    }


    


}

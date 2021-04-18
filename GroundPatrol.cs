using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPatrol : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rayCastDistance = 2f;
    public Rigidbody2D rb;
    private bool movingRight = true;
    public Transform groundDetection;
    public LayerMask terrainLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
  
    }
   

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveSpeed, 0);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayCastDistance, terrainLayer);

        if (groundInfo.collider == false)
        {

            if (movingRight)
            {
                Debug.Log("at Right Edge");
              
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                moveSpeed = -3;
                movingRight = false;
            }
            else if (movingRight == false)

            {
                Debug.Log("at Left Edge");
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                moveSpeed = 3;
                movingRight = true;
            }
        }

    }
}

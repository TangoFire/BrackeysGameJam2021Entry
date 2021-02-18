using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPatrol : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float groundInfoRayLength = 2f;
    private bool movingRight = true;
    public Transform groundDetection;
    public Rigidbody2D rb;


    // Update is called once per frame
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
  
    
     void FixedUpdate()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, groundInfoRayLength);
        Debug.Log(groundInfo.collider.name);

        if (groundInfo.collider.name == "TerrainBlock")
        {
            Vector2 direction = Vector2.right.normalized;
            Vector2 velocity = direction * moveSpeed;
            Vector2 movement = velocity * Time.fixedDeltaTime;

            rb.MovePosition((Vector2)transform.position + movement);
            Debug.Log("Moving Right");
        }

        if (groundInfo.collider == false)
        {

        }
    }

}

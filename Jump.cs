using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider2D;
    public float jumpVelocity = 200f;
    public LayerMask terrainLayer;
    float rayCastDistance = .5f;

    void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
        }
    }

    private bool isGrounded()
    {
        
        RaycastHit2D groundCheckRayCast = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, rayCastDistance, terrainLayer);
        Color rayColor;
        if(groundCheckRayCast.collider != null)
        {
            rayColor = Color.green;
            Debug.Log("Grounded");
            Debug.Log(groundCheckRayCast.collider);
        }
        else
        { 
            rayColor = Color.red;
            Debug.Log("Not Grounded");
        }


        Debug.DrawRay(boxCollider2D.bounds.center + new Vector3(boxCollider2D.bounds.extents.x, 0), Vector2.down * (boxCollider2D.bounds.extents.y + rayCastDistance), rayColor); 
        Debug.DrawRay(boxCollider2D.bounds.center - new Vector3(boxCollider2D.bounds.extents.x, 0), Vector2.down * (boxCollider2D.bounds.extents.y + rayCastDistance), rayColor);
       


        return groundCheckRayCast.collider != null;
    }
}

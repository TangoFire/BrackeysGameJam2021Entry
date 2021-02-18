using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPatrol : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public float groundInfoRayLength = 2f;
    public int terrainLayer = 9;
    private bool movingRight;


  void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(GetComponent<BoxCollider2D>().bounds.extents, Vector2.down, groundInfoRayLength);

        if (groundInfo.collider.gameObject.layer == terrainLayer)
        {
            Debug.Log("Hit Ground");
            rb.MovePosition((Vector2.right) * moveSpeed * Time.deltaTime);
            movingRight = true;
        }
    }
}

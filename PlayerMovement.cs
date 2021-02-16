using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
        public float moveSpeed = 5f;

        public Rigidbody2D rb;

        
        Vector2 input;
     


        private void Awake()
        {
            rb.GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

          
        }
        void FixedUpdate()
        {
            Vector2 direction = input.normalized;
            Vector2 velocity = direction * moveSpeed;
            Vector2 movement = velocity * Time.fixedDeltaTime;

            rb.MovePosition((Vector2)transform.position + movement);

            
        }
    
}

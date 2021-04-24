using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDmg = 5;
    public bool beingSpitOut = false;


    private void FixedUpdate()
    {
        if (beingSpitOut)
        {
            Debug.Log(gameObject.name + " is being Spit Out");
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            beingSpitOut = false;
        }
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.name == "Player") && (beingSpitOut != true)) 
        {
            Debug.Log("Player takes " + attackDmg + " damage");
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(attackDmg);

           

        }

    }

   





}

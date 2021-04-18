using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDmg = 5;
   


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Player takes " + attackDmg + " damage");
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(attackDmg);
        }
    }







}

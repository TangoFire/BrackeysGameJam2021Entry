using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDmg = 5;
    public bool isEaten = false;


    private void Update()
    {
        if (isEaten)
        {
            Debug.Log(gameObject + " has had damage set to 0");
            attackDmg = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isEaten != true) 
        {
            if (collision.gameObject.name == "Player")
            {
                Debug.Log("Player takes " + attackDmg + " damage");
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(attackDmg);



            }
        }
    }

   





}

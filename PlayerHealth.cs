using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 25;

    public void TakeDamage(int attackDmg)
    {
        playerHealth -= attackDmg;
        Debug.Log("Player has " + playerHealth + " Health remaining.");


        if (attackDmg > playerHealth)
        {
            PlayerDeath();
        }
    }

    
    public void PlayerDeath()
    {
        Destroy(gameObject);
        Debug.Log("Player Dies");
    }
}
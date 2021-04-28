using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 25;
    public int maxPlayerHealth = 25;
   
    public void TakeDamage(int attackDmg)
    {
        playerHealth -= attackDmg;
        Debug.Log("Player has " + playerHealth + " Health remaining.");


        if (attackDmg > playerHealth)
        {
            PlayerDeath();
        }
    }

    public void HealPlayerHealth(int healAmount)
    {
        if (playerHealth < maxPlayerHealth)
        {
            playerHealth += healAmount;
            Debug.Log("Player has healed " + healAmount);
            Debug.Log(playerHealth);
        }
    }
    public void PlayerDeath()
    {
        Destroy(gameObject);
        Debug.Log("Player Dies");
        Camera.main.transform.parent = null;
        

    }
}
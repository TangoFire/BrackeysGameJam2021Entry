﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BiteAttack : MonoBehaviour
{
    public Transform bitePoint;
    public int healAmount = 5;
    public float deathRotationSpeed = 100f;
    public float biteRange = 1f;
    public float spitLaunchSpeed = 100f;
    public LayerMask enemyLayers;
    public Vector3 originalScale;
    private Collider2D enemy;
    private bool bellyFull = false;
    private bool hasMorphed = false;
    private Component patrolScript;

    private string eatenEnemyType;


    private void Awake()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        BiteAttackMorph();

        if (Input.GetMouseButtonDown(0))
        {
            if (enemy == null)
            {
                Eat();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            SpitAttack();
        }
    }

    
    
    
    void SpitAttack()
    {
        Debug.Log("Spit");

        if (enemy != null)
        {
            Debug.Log("Spitting out " + enemy);
            bellyFull = false;
            enemy.transform.position = bitePoint.transform.position;
            enemy.gameObject.SetActive(true);     
            enemy.gameObject.GetComponent<EnemyAttack>().enabled = false;
            enemy.gameObject.transform.eulerAngles = new Vector3(0f, 0f, 180f);


            if (transform.localScale.x < 0)
            {
                enemy.attachedRigidbody.AddForce(new Vector2(-spitLaunchSpeed, 0), ForceMode2D.Impulse);
            }
            if (transform.localScale.x > 0)
            {
                enemy.attachedRigidbody.AddForce(new Vector2(spitLaunchSpeed, 0), ForceMode2D.Impulse);
            }
            enemy = null;
        }
    }
    
    void Eat()
    {
        Debug.Log("Eat");
        enemy = Physics2D.OverlapCircleAll(bitePoint.position, biteRange, enemyLayers).FirstOrDefault();
        if(enemy != null)
        {
            Debug.Log("Hit " + enemy.name);
            enemy.gameObject.SetActive(false);
            enemy.gameObject.GetComponent<EnemyAttack>().isEaten = true;
            bellyFull = true;
            GetEnemyType();
            patrolScript = enemy.gameObject.GetComponent<GroundPatrol>();
            Destroy(patrolScript);
        }
    }
    
    
    void BiteAttackMorph()
    {
        if (bellyFull)
        {
            Debug.Log("Player is full");
        }

    
        
        if(bellyFull && Input.GetKeyDown(KeyCode.E))
        {
            if (hasMorphed != true)
            {
               //What Morph will do
                transform.localScale = transform.localScale * 1.2f;
                GetComponent<PlayerHealth>().HealPlayerHealth(healAmount);
                Destroy (enemy.gameObject);
                hasMorphed = true;
            }
        }

        if (bellyFull == false)
        {
            Debug.Log("Player has not eaten");
            if (hasMorphed)
            {
                transform.localScale = originalScale;
            }
        }
    }
    
    
    public void GetEnemyType()
    {
        if (enemy.gameObject.layer == 20)
        {
            Debug.Log("You have eaten a Walker Type Enemy");
            
        }

        if (enemy.gameObject.layer == 21)
        {
            Debug.Log("You have eaten a Flying Type Enemy");
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (bitePoint == null)
            return;
        Gizmos.DrawWireSphere(bitePoint.position, biteRange);
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BiteAttack : MonoBehaviour
{
    public Transform bitePoint;
    public float biteRange = 1f;
    public float spitLaunchSpeed = 100f;
    public LayerMask enemyLayers;
    public Vector3 originalScale;
    private Collider2D enemy;
    private bool bellyFull = false;
    private bool hasMorphed = false;
    public Component patrolScript;

    private void Awake()
    {
        originalScale = transform.localScale;
        
        if (bellyFull)
        {
            patrolScript = enemy.gameObject.GetComponent<GroundPatrol>();
        }
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
            // patrolScript.gameObject.SetActive(true);
            patrolScript.gameObject.SetActive(false);
            enemy.gameObject.GetComponent<EnemyAttack>().beingSpitOut = true;
       


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
            bellyFull = true;
            patrolScript = enemy.gameObject.GetComponent<GroundPatrol>();
            
            patrolScript.gameObject.SetActive(false);
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
               
                transform.localScale = transform.localScale * 1.2f;
                
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





    private void OnDrawGizmosSelected()
    {
        if (bitePoint == null)
            return;
        Gizmos.DrawWireSphere(bitePoint.position, biteRange);
    }
}
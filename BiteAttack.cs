using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BiteAttack : MonoBehaviour
{
    public Transform bitePoint;
    public float biteRange = 1f;
    public float spitLaunchSpeed = 10f;
    public LayerMask enemyLayers;
    private Collider2D enemy;
   


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Eat();
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
            enemy.transform.position = bitePoint.transform.position;
            enemy.gameObject.SetActive(true);
            enemy.attachedRigidbody.velocity = Vector2.right * spitLaunchSpeed;
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
           
          
        }

       
    }

    private void OnDrawGizmosSelected()
    {
        if (bitePoint == null)
            return;
        Gizmos.DrawWireSphere(bitePoint.position, biteRange);
    }
}
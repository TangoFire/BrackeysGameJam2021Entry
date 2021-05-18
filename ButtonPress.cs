using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public GameObject buttonEffect;
    
    private float originalButtonSizeX;
    private float originalButtonSizeY;
    
    private Transform button;


    public Transform buttonUpPosition;
    public Transform buttonDownPosition;
    private float buttonTravel = .15f;


    void Awake()
    {

        button = GetComponent<Transform>();
        originalButtonSizeX = button.position.x; 
        originalButtonSizeY = button.position.y;
    }

  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        button.position = new Vector2(originalButtonSizeX, originalButtonSizeY);
        

        Debug.Log("Button has been pressed.");
       
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        button.position = new Vector2(originalButtonSizeX, originalButtonSizeY);


        Debug.Log("Button has been pressed.");

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        button.position = new Vector2(originalButtonSizeX, originalButtonSizeY + buttonTravel);
        Debug.Log("Button has been released.");
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public GameObject buttonEffect;
    private float originalButtonSizeY;
    private float originalButtonSizeX;
    private float buttonPressedSize = .05f;
    private Transform objectSize;


    void Awake()
    {
       
         originalButtonSizeX = this.objectSize.localScale.x;
          originalButtonSizeY = this.objectSize.localScale.y;
        
    }

  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Button has been pressed.");
        transform.localScale = new Vector3(originalButtonSizeX, buttonPressedSize);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Button has been released.");
        transform.localScale = new Vector3(originalButtonSizeX, originalButtonSizeY);
    }
}

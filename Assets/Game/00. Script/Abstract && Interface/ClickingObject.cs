using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickingObject : MonoBehaviour
{
    protected void CheckingMouse()
    {
         if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera's position and direction
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Create a RaycastHit variable to store information about the hit
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the raycast hit a game object
                GameObject clickedObject = hit.collider.gameObject;

                // Do something with the clicked object
                DoingSomething();
            }
        }

    }

    public abstract void DoingSomething();
}

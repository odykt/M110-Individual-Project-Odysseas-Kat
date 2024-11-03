using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
 
    [SerializeField]
    UnityEvent interactionEvent;
    [SerializeField]
    UnityEvent targetEvent;
    [SerializeField]
    UnityEvent unTargetEvent;

 
    public void Target()
    {
        targetEvent?.Invoke();
    }

    public void UnTarget()
    {
        unTargetEvent?.Invoke();
    }

    public void Interact()
    {
        // Simple interaction logic, e.g., pick up the item or trigger an event
        Debug.Log("Interacted with " + gameObject.name);

        // Do smth here or add it to the exposed UnityEvent on Unity Editor
        interactionEvent?.Invoke(); 
    }


    #region examples


    public void OnPickUp()
    {
        Debug.Log(gameObject.name + " picked up!");
        // You can either disable or destroy the object
        gameObject.SetActive(false);
        //add to inventory?
    }

    


    #endregion
}


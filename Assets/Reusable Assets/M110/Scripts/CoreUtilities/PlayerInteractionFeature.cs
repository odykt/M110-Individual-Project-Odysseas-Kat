using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionFeature : MonoBehaviour
{
    [SerializeField]
    InteractableObject activeTarget;
    void OnTriggerEnter(Collider collision)
    {
        activeTarget = collision.gameObject.GetComponent<InteractableObject>();

        if (activeTarget != null)
        {
            activeTarget.Target();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (activeTarget != null)
        {
            activeTarget.UnTarget();
        }
        activeTarget = null;
    }

    public void OnInteractWithItem()
    {
        if (activeTarget != null) 
        {
            activeTarget.Interact();
        }
    }
}

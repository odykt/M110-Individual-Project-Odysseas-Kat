using UnityEngine;

public class ColliderParent : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {

        // Do your stuff here
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Called on trigger Enter");
        // Do your stuff here
    }
}

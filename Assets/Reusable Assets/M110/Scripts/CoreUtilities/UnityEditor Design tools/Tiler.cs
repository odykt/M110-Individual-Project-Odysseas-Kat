using UnityEngine;

/*
 * 
 */

public enum MovementAxis
{

}
public class Tiler : MonoBehaviour
{
    /// Public Properties
    public float xAxisDistance;
    public float yAxisDistance;

    public Transform referencePosition;

    public Transform[] items;
    public MovementAxis movementAxis;
    /// Serialized Fields for Editor
#pragma warning disable 0649

#pragma warning restore 0649
    [ContextMenu("Register&DistributeH")]
    public void RegisterNDistributeH()
    {
        RegisterChildren();
        DistributeHorizontal();
    }
    [ContextMenu("Register&DistributeV")]
    public void RegisterNDistributeV()
    {
        RegisterChildren();
        DistributeVertical();
    }

    [ContextMenu("Register")]
    public void RegisterChildren()
    {
        items = transform.FetchAllChildrenT();
    }

    [ContextMenu("DistributeHorizontally")]
    public void DistributeHorizontal()
    {
        if (referencePosition == null)
            referencePosition = this.transform;

        for (int i = 0; i < items.Length; i++)
        {
            items[i].position = referencePosition.position + i * Vector3.right * xAxisDistance;
        }
    }
    [ContextMenu("DistributeVertically")]
    public void DistributeVertical()
    {
        if (referencePosition == null)
            referencePosition = this.transform;

        for (int i = 0; i < items.Length; i++)
        {
            items[i].position = referencePosition.position + i * Vector3.up * yAxisDistance;
        }
    }

}


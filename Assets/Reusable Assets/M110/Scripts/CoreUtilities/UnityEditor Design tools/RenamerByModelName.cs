using UnityEngine;

public class RenamerByModelName : MonoBehaviour
{
    [ContextMenu("RenameGameObject")]

    public void RenameGameObject()
    {
        this.gameObject.name = this.GetComponent<MeshFilter>().sharedMesh.name;
    }
}

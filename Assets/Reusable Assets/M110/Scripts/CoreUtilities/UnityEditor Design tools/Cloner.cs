using UnityEngine;

public class Cloner : MonoBehaviour
{
    public GameObject prototype;
    public Transform container;
    public float times;

    ///  Public Methods
    [ContextMenu("Clone")]
    public void Clone()
    {
        for (int i = 0; i < times; i++)
        {
            GameObject go = Instantiate(prototype, transform);
            go.name = prototype.name + "_" + i;
        }
    }


    public void CloneOnce()
    {
        Clone(prototype, container);
    }

    void Clone(GameObject prototype, Transform parent)
    {
        Instantiate(prototype, parent);
    }

}

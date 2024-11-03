using UnityEngine;

public class RenamerGameObject : MonoBehaviour
{

    [SerializeField]
    string basename;

    [SerializeField]
    GameObject[] objs;

    [ContextMenu("Rename")]
    public void Rename()
    {
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].name = basename + (i + 1);
        }
    }

}

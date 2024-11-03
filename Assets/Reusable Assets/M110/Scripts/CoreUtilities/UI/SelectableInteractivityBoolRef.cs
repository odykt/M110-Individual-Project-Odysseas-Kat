using NM.ValueDataRefWrapper;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class SelectableInteractivityBoolRef : MonoBehaviour
{
    [SerializeField]
    Selectable selectable;
    [SerializeField]
    bool shouldInvertBoolValue;
    [SerializeField]
    bool runInUpdate;
    [SerializeField]
    boolReference boolReference;

    private void OnEnable()
    {
        if (selectable == null)
        {
            selectable = GetComponent<Selectable>();
        }
        SetInteractivity();
    }

    private void Update()
    {
        if (runInUpdate) { SetInteractivity(); }
    }

    [Button]
    void SetInteractivity()
    {
        if (shouldInvertBoolValue) { selectable.interactable = !boolReference.Value; }
        else
        { selectable.interactable = boolReference.Value; }

    }
}

using NM.ValueDataRefWrapper;
using UnityEngine;
using UnityEngine.UI;

public class BoolRefEditor : MonoBehaviour
{
    [Header("GetComponent if null")]
    [SerializeField]
    Toggle toggle;

    [Space]
    [Header("Design")]
    [SerializeField]
    boolReference boolReference;


    [SerializeField]
    bool shouldInverse;

    private void Awake()
    {
        if (toggle == null)
        {
            toggle.GetComponent<Toggle>();
        }

        if (toggle != null)
            toggle.onValueChanged.AddListener(EditValue);
    }

    void EditValue(bool tof)
    {
        if (shouldInverse)
        {
            boolReference.SetValue(!tof);
        }
        else
        {
            boolReference.SetValue(tof);
        }

    }

    //for external void calls
    public void SetValueTo(bool tof)
    {
        EditValue(tof);
    }

}

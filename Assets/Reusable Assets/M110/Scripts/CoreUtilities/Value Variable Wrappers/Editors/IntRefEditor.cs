using NM.ValueDataRefWrapper;
using TMPro;
using UnityEngine;

public class IntRefEditor : MonoBehaviour
{
    public intReference intReference;

    [SerializeField]
    TMP_InputField inputfield;


    private void Awake()
    {
        if (inputfield != null)
            inputfield.onEndEdit.AddListener(EditValue);
    }

    void EditValue(string input)
    {
        if (int.TryParse(input, out int value))
        {
            intReference.SetValue(value);
        }
        else
        {
            Debug.Log("Improper value");
        }
    }

    public void ForceSetValue(int value)
    {
        intReference.SetValue(value);
    }
}

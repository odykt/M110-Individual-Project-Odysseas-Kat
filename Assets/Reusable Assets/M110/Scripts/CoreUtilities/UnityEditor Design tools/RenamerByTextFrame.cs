using TMPro;
using UnityEngine;

public class RenamerTextFrame : MonoBehaviour
{
    [ContextMenu("Rename")]
    void Rename()
    {
        TextMeshProUGUI textMeshProUGUI = GetComponent(typeof(TMPro.TextMeshProUGUI)) as TextMeshProUGUI;
        gameObject.name = textMeshProUGUI.text;
    }

}

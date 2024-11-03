using NM.ValueDataRefWrapper;
using UnityEngine;

public class BoolModeToggleManager : MonoBehaviour
{

    [SerializeField]
    boolReference boolReference;
    public void SetMode(bool tof)
    {
        boolReference.SetValue(tof);
    }

    public void ToggleMode()
    {
        boolReference.SetValue(!boolReference.Value);
    }
}

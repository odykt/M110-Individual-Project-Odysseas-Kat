using UnityEngine;

namespace NM.ValueDataRefWrapper
{
    [CreateAssetMenu(fileName = "NewFloatReference", menuName = "ValueAsRefSOs/float Reference", order = 2)]
    public class floatReference : ValueTypeAsRefBase<float>
    {
        public void SetValue(string input)
        {
            base.SetValue(float.Parse(input));
        }
    }
}
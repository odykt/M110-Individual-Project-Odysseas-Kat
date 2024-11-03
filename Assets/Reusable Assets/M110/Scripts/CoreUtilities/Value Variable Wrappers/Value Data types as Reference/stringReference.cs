using System;
using UnityEngine;

namespace NM.ValueDataRefWrapper
{
    [CreateAssetMenu(fileName = "NewStringReference", menuName = "ValueAsRefSOs/string Reference", order = 4)]
    [Serializable]
    public class stringReference : ValueTypeAsRefBase<string>
    {

    }

}
using UnityEngine;

namespace NM.ValueDataRefWrapper
{
    public class primitiveVariable<T>
    {
        [SerializeField]
        bool useReference;

        [Tooltip("Local value reflects reference value for debugging is useReference is selected")]
        [SerializeField]
        T localValue;

        [SerializeField]
        ValueTypeAsRefBase<T> refValue;
        public T value { get { return useReference ? refValue.Value : localValue; } }


        public void SetValue(T input)
        {
            if (useReference)
            {
                localValue = input;
                refValue.SetValue(input);
            }
            else
                localValue = input;

        }

        public void AssignRefSO(ValueTypeAsRefBase<T> incoming)
        {
            refValue = incoming;
            useReference = true;
        }

    }
}

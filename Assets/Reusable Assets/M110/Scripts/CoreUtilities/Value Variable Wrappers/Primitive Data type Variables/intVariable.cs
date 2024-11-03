using NM.ValueDataRefWrapper;
using System;

[Serializable]
public class intVariable : primitiveVariable<int>
{
    //[SerializeField]
    //int localValue;
    //[SerializeField]
    //public intReference refValue;

    //public bool useReference;

    //public int value { get { return useReference ? refValue.Value : localValue;} }

    //public void SetValue(int input)
    //{
    //    if (useReference)
    //        refValue.SetValue(input);
    //    else localValue = input;

    //}

    //public void AssignRefSO(intReference incoming)
    //{
    //    refValue = incoming;
    //}
}

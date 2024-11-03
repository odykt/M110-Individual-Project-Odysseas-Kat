using UnityEngine;

public class ValueTypeAsRefBase<T> : ScriptableObject
{
    [SerializeField]
    [TextArea]
    protected T value;

    public T Value
    {
        get { return value; }

    }

    public void SetValue(T input)
    {
        value = input;
    }

}

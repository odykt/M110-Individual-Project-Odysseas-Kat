using UnityEngine;

namespace NM.ValueDataRefWrapper
{
    [CreateAssetMenu(fileName = "NewIntReference", menuName = "ValueAsRefSOs/int Reference", order = 1)]
    public class intReference : ValueTypeAsRefBase<int>
    {
        //private int value;

        //public int Value
        //{
        //    get { return value; }
        //}

        //public void SetValue(int input)
        //{
        //    value = input;
        //}

        public bool TrySetValue(string input)
        {
            if (int.TryParse(input, out int newValue))
            {
                value = newValue;
                return true;
            }
            else
            { return false; }
        }

        public void SetValue(string input)
        {
            if (int.TryParse(input, out int newValue))
            {
                value = newValue;
            }
        }
    }
}
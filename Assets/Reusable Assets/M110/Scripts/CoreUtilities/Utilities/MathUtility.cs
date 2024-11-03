using System;


//add here some functionality related to math that is not implemented in
//System.Mathf
//System.Math
//or
//Unity.Mathf
public static class MathUtility
{
    public static bool IsNumberEven(this int input)
    {
        int remainder;
        Math.DivRem(input, 2, out remainder);
        return (remainder == 0);
    }
}

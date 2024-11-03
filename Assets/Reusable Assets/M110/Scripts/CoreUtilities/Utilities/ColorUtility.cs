using UnityEngine;

//add here common function you would like to do with the Color struct that are not already implemented.
//add as extensions.
public static class ColorUtility
{
    public static Color Darken(this Color input, float percent)
    {

        float h;
        float s;
        float v;

        Color.RGBToHSV(input, out h, out s, out v);

        v = v * percent;

        Color newColor = Color.HSVToRGB(h, s, v);

        return newColor;
    }


}

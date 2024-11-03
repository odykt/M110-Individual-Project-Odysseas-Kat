using UnityEngine;

//add here some common functionality related to text
public static class TextUtilities
{
    public enum LineEndingFormat
    {
        Windows,
        Linux
    }

    public static string[] ReadLinesFromText(TextAsset textAsset, LineEndingFormat lineEndingFormat)
    {
        string text = textAsset.text;
        if (!string.IsNullOrEmpty(text))
        {
            return SplitStringToLines(text, lineEndingFormat);
        }
        else
        {
            Debug.Log("File " + textAsset.name + " has no contents.");
            return null;
        }

    }
    public static string[] SplitStringToLines(string text, LineEndingFormat lineEndingFormat)
    {
        //TODO: consider what should be done here if the lines are in \n only.
        switch (lineEndingFormat)
        {
            case LineEndingFormat.Windows:
                return text.Split("\r\n", System.StringSplitOptions.RemoveEmptyEntries);

            case LineEndingFormat.Linux:
                return text.Split("\n", System.StringSplitOptions.RemoveEmptyEntries);
            default:
                return null;
        }
    }


    /// <summary>
    /// Expected in format (x.xxx, y.yyy)
    /// </summary>
    /// <param name="coordsPerLine"></param>
    /// <returns></returns>
    public static Vector2[] ReadCoordsFromText(string[] coordsPerLine)
    {
        if (coordsPerLine.Length > 0)
        {
            Vector2[] coords = new Vector2[coordsPerLine.Length];

            for (int i = 0; i < coordsPerLine.Length; i++)
            {
                coords[i] = ReadCoordsFromText(coordsPerLine[i]);
            }
            return coords;
        }
        else
        {
            Debug.Log("ReadCoordsFromText cannot read input - empty array");
            return null;
        }
    }

    public static Vector2 ReadCoordsFromText(string coordEntry)
    {
        int index = coordEntry.IndexOf(",");
        //returns -1 if not found
        if (index != -1)
        {
            float.TryParse(coordEntry.Substring(0, index), out float xValue);
            float.TryParse(coordEntry.Substring(index + 1, coordEntry.Length - index - 1), out float yValue);
            return new Vector2(xValue, yValue);
        }
        else
        {
            Debug.Log("ReadCoordsFromText cannot read input - improperly formatted");
            return Vector2.zero;
        }
    }



}

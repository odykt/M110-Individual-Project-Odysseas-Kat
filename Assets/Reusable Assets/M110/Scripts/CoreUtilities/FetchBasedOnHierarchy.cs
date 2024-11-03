using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;


public static class FetchBasedOnHierarchy
{
    public static GameObject[] FetchAllChildren(this GameObject gameObject)
    {
        int childrenCount = gameObject.transform.childCount;
        GameObject[] allchildren = new GameObject[childrenCount];

        for (int i = 0; i < childrenCount; i++)
        {
            allchildren[i] = gameObject.transform.GetChild(i).gameObject;
        }

        return allchildren;
    }

    public static Transform[] FetchAllChildrenT(this Transform gameObject)
    {
        int childrenCount = gameObject.childCount;
        Transform[] allchildren = new Transform[childrenCount];

        for (int i = 0; i < childrenCount; i++)
        {
            allchildren[i] = gameObject.GetChild(i);
        }

        return allchildren;
    }

    public static GameObject FetchFirstChild(this GameObject gameObject)
    {
        float childrenCount = gameObject.transform.childCount;
        //if you find at least 1 child, get the first
        if (childrenCount >= 1)
        {
            return gameObject.transform.GetChild(0).gameObject;
        }
        else
        {
            Debug.LogError("No children found!");
            return new GameObject(); //which will be null. How do I do this properly?
        }
    }

    public static GameObject[] FetchOtherSameLevelSiblings(this GameObject target)
    {
        Transform parent = target.transform.parent;

        int count = parent.childCount;

        GameObject[] allchildren = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            allchildren[i] = parent.GetChild(i).gameObject;
        }

        List<GameObject> siblings = new List<GameObject>();

        //exclude this gameobject
        foreach (GameObject sibling in allchildren)
        {
            //this should better be changed to a unique identifier
            if (sibling.name != target.gameObject.name)
            {
                siblings.Add(sibling);
            }
        }

        return siblings.ToArray();

    }

    public static GameObject FetchTopLevelParent(this GameObject gameObject)
    {
        return gameObject.transform.root.gameObject;
    }

    public static GameObject FetchClosestParentWithTag(this GameObject gameObject, string tag)
    {
        string desiredTag = tag;

        GameObject desiredObject = new GameObject();
        GameObject objectUnderInvestigation;
        objectUnderInvestigation = gameObject.transform.parent.gameObject;

        int depthIndex = gameObject.transform.hierarchyCount;

        int i = 0;

        while (i < depthIndex - 1)
        {
            if (objectUnderInvestigation.CompareTag(desiredTag))
            {
                desiredObject = objectUnderInvestigation;
                break;
            }
            else
            {
                objectUnderInvestigation = objectUnderInvestigation.transform.parent.gameObject;
                i++;
            }
        }
        return desiredObject;
    }

    /// <summary>
    /// Returns all gameobjects found under Allfather, whose name matches the calling objects name for the first few digits.
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="AllFather"></param>
    /// <returns></returns>
    public static GameObject[] MatchWithNameGREP(this GameObject gameObject, GameObject AllFather)
    {
        GameObject[] collection = AllFather.FetchAllChildren();

        string identifier = gameObject.name.ToLower().Substring(0, 4);

        Regex rgx = new Regex(identifier + "*");

        List<GameObject> list = new List<GameObject>();

        foreach (var item in collection)
        {
            if (rgx.IsMatch(item.gameObject.name.ToLower()))
            {
                list.Add(item);
            }
        }
        return list.ToArray();
    }


    public static T[] ReturnASetAsComponent<T>(this GameObject[] gos)
    {
        T[] returnSet = new T[gos.Length];

        for (int i = 0; i < gos.Length; i++)
        {
            returnSet[i] = gos[i].GetComponent<T>();
        }
        return returnSet;
    }

    public static GameObject[] SelectGameObjectsWithComponent<T>(this GameObject[] aSet)
    {
        IEnumerable<GameObject> subset = aSet.Where(item => item.GetComponent<T>() != null);

        return subset.ToArray();
    }

    /// <summary>
    /// Returns a subset of GameObjects as an array of their components (filter by T).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="aBiggerSet"></param>
    /// <returns></returns>
    public static T[] FishOutGosWithComponent<T>(this GameObject[] aBiggerSet)
    {
        return ReturnASetAsComponent<T>(SelectGameObjectsWithComponent<T>(aBiggerSet));
    }

}

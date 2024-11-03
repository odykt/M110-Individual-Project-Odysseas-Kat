using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu]
public class GameEventVariable : ScriptableObject
{

    public List<string> listenerNames = new List<string>();
    public List<GameObject> listenerObjects = new List<GameObject>();

    private readonly List<GameEventListener> eventListeners =
            new List<GameEventListener>();


    public void Raise()
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
            eventListeners[i].OnEventRaised();

        //Debug.Log( "Raised event of type " + this.name);
    }

    public void RegisterListener(GameEventListener listener)
    {
        if (!eventListeners.Contains(listener))
        {
            eventListeners.Add(listener);
            listenerNames.Add(listener.gameObject.name);
            listenerObjects.Add(listener.gameObject);
        }
    }

    public void UnregisterListener(GameEventListener listener)
    {
        if (eventListeners.Contains(listener))
        {
            eventListeners.Remove(listener);
            listenerNames.Remove(listener.gameObject.name);
            listenerObjects.Remove(listener.gameObject);
        }
    }
}

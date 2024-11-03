using UnityEngine;

public class DontDisableSOs : MonoBehaviour
{
    public static DontDisableSOs Instance;

    [SerializeField]
    ScriptableObject[] valuesToKeepLoaded;


    //DontDestroySOs Instance;
    private void Awake()
    {
        //do NOT use the singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this);
        }

    }
}

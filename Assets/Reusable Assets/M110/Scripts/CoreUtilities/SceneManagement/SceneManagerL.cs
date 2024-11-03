using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class SceneManagerL : MonoBehaviour
{
    public static SceneManagerL Instance;

    [SerializeField]
    floatVariable minimumDelay;

    [SerializeField]
    GameEventVariable appQuitting;

    [SerializeField]
    GameEventVariable sceneLoading;

    [SerializeField]
    Scene homeScene;

    [SerializeField]
    bool loadAdditive;
    [SerializeField]
    bool loadAsync;


    [SerializeField]
    GameEventVariable SceneLoadStarted;
    //optional version 3 calculate exact duration 
    [SerializeField]
    GameEventVariable SceneLoadFinished;

    //version 2 announce it with the call
    [SerializeField]
    UnityEvent<float> SceneLoadStartedE;

    [SerializeField]
    GameEventVariable AppQuitStarted;

    private void Awake()
    {
        Instance = this;

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    [ContextMenu("ReloadScene")]
    public void ReloadScene()
    {
        ChangeScene(SceneManager.GetActiveScene().buildIndex);
    }
    [ContextMenu("ReloadScene")]
    public void ChangeSceneToHome()
    {
        ChangeScene(homeScene.buildIndex);
    }

    public void ChangeScene(int index)
    {
        if (loadAsync)
        {
            StartCoroutine(AsyncLoadWithMinWait());
        }
        else
        {
            SceneLoadStarted?.Raise();
            SceneManager.LoadScene(index);
        }


        IEnumerator AsyncLoadWithMinWait()
        {
            SceneLoadStarted?.Raise();
            SceneLoadStartedE?.Invoke(minimumDelay.value);

            //why is there concern for this?
            Time.timeScale = 1;
            yield return new WaitForSecondsRealtime(minimumDelay.value);

            AsyncOperation async = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
            yield return new WaitUntil(() => async.isDone);
            Debug.Log("Scene added");
            SceneLoadFinished?.Raise();
        }

    }

    [ContextMenu("ApplicationQuit")]
    public void ApplicationQuit()
    {
        AppQuitStarted?.Raise();
        StartCoroutine(Wait());

        IEnumerator Wait()
        {
            //why is there concern for this?
            Time.timeScale = 1;
            yield return new WaitForSecondsRealtime(minimumDelay.value);
            Application.Quit();

#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
        }

    }


}

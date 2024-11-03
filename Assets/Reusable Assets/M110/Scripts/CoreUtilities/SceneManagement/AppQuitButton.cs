using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AppQuitButton : MonoBehaviour
{
    Button button;
    // Start is called before the first frame update
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(QuitApp);
    }

    // Update is called once per frame
    void QuitApp()
    {
        SceneManagerL.Instance.ApplicationQuit();
    }
}

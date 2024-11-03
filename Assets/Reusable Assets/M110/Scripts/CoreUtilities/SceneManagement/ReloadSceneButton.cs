using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ReloadSceneButton : MonoBehaviour
{
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ClickAction);
    }

    void ClickAction()
    {
        SceneManagerL.Instance.ReloadScene();
    }
}


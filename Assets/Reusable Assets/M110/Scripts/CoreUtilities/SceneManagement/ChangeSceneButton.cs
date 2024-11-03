using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChangeSceneButton : MonoBehaviour
{

    [SerializeField]
    int index;
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ClickAction);
    }

    void ClickAction()
    {
        SceneManagerL.Instance.ChangeScene(index);
    }
}


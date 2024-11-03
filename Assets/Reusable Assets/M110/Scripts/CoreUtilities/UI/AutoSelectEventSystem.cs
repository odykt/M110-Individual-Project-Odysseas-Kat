using UnityEngine;
using UnityEngine.EventSystems;

public class AutoSelectEventSystem : MonoBehaviour
{
    // Start is called before the first frame update

    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMainMenu : MonoBehaviour
{
 
    [SerializeField]
    GameObject mainMenu;
    public void OnToggleMainMenu()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
    }
}

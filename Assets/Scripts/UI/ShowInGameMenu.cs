using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInGameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    public void ShowMenu()
    {
        if (CustomSceneManager.instance.CurrentScene() != "Main Menu" && !menu.activeInHierarchy) GameManager.instance.ShowGameMenu();
    }
}

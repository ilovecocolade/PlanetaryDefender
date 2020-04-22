using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void ButtonPlay() { SceneManager.LoadScene(1); }

    public void ButtonQuit() { Application.Quit(); }

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}

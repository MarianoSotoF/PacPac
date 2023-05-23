using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryScreen_functions : MonoBehaviour
{
    void Start() {
        // Pause time
        Time.timeScale = 0f;
    }

    //Exit to main menu
    public void BackMainMenu(){
        SceneManager.LoadScene("Main_Menu");
        Cursor.visible = !Cursor.visible;
        Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
    }
}

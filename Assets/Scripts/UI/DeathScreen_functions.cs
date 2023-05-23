using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen_functions : MonoBehaviour
{
    private Button Restart_button;
    private Button Return_button;
    private Text DeathText;

    // Start is called before the first frame update
    void Start()
    {
        // Pause time
        Time.timeScale = 0f;
        //Random advise text
        string[] DeathMessages = new string[]{"Keep your light save... IT's dark...",
                                              "It's fast... don't look away",
                                              "Don't look back... but keep an eye on heights.",
                                              "It's small... get hid."};

        //Get death text and randomly select message to show
        DeathText = this.transform.GetChild(1).GetComponent<Text>();
        DeathText.text = DeathMessages[Random.Range(0, DeathMessages.Length)];
    }

    //Reset current level
    public void Restart(){
        Cursor.visible = !Cursor.visible;
        Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Exit to main menu
    public void Exit(){
        Debug.Log("Volviendo al Menu Principal...");
        SceneManager.LoadScene("Main_Menu");
        Cursor.visible = !Cursor.visible;
        Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
        Time.timeScale = 0f;
    }
}

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
        string[] DeathMessages = new string[]{"Keep your light save... IT's dark...",
                                              "It's fast... don't look away", 
                                              "Don't look back... but keep an eye on heights.",
                                              "It's small... get hid."};

        //Get death text and randomly select message to show
        DeathText = this.transform.GetChild(1).GetComponent<Text>();
        DeathText.text = DeathMessages[Random.Range(0, DeathMessages.Length)];
        //Get reset button and add its functionality
        Restart_button = GameObject.FindWithTag("DeathRestartButton").GetComponent<Button>();
        Restart_button.onClick.AddListener(ResetLevel);
        //Get return button and add its functionality
        Return_button = GameObject.FindWithTag("DeathReturnButton").GetComponent<Button>();
        Return_button.onClick.AddListener(ReturnToMenu);
    }

    void ResetLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ReturnToMenu(){
        SceneManager.LoadScene("Main_Menu");
    }
}

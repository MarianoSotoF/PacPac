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
        string[] DeathMessages = new string[]{"No pierdas tu luz... está oscuro...", 
                                              "Es rapido... no apartes la mirada...",
                                              "Siempre mira al frente... pero vigila las alturas",
                                              "Es pequeño... evita que te vea..."};

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
        //Por implementar
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Pausa : MonoBehaviour
{

    [SerializeField] private GameObject bPausa;
    [SerializeField] private GameObject mPausa;

    private bool jPausa = false;

    private void update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (jPausa)
            {
                Resume();
            }
            else
            {
                Pausa();
            }
        }

    }

    public void Pausa()
    {
        jPausa = true;
        Time.timeScale = 0f;
        bPausa.SetActive(false);
        mPausa.SetActive(true);

    }

    public void Resume()
    {

        jPausa = false;
        Time.timeScale = 1f;
        bPausa.SetActive(true);
        mPausa.SetActive(false);

    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Debug.Log("Volviendo al Menu Principal...");
        SceneManager.LoadScene("Main_Menu");
    }
}

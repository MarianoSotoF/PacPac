using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Pausa : MonoBehaviour
{

    [SerializeField] private GameObject mPausa;
    [SerializeField] private GameObject mPausa_Options;

    [Header("Options")]
    public Slider volume;
    public Slider fxvolume;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxsource;
    public AudioClip ClickSound;
    private float lastvolume;

    private bool jPausa = false;

    private void Start() {

        mixer.SetFloat("VOLMASTER", -80);
        
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (Cursor.visible == false)
            {

                Cursor.visible = !Cursor.visible;
                Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;

            }
            Debug.Log("Pausa");
            
            if (jPausa)
            {
                mixer.SetFloat("VOLMASTER", -80);
                Resume();
            }
            else
            {
                Pausa();
                mixer.SetFloat("VOLMASTER", 0);         
            }
        }

    }

    public void Pausa()
    {
        Cursor.visible = true;

        jPausa = true;
        Time.timeScale = 0f;
        mPausa.SetActive(true);
        PlaySoundButton();

    }

    public void Resume()
    {
        mixer.SetFloat("VOLMASTER", -80);

        mPausa.SetActive(false);
        Time.timeScale = 1f;
        jPausa = false;

    }

    public void Restart()
    {
        mixer.SetFloat("VOLMASTER", -80);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Debug.Log("Volviendo al Menu Principal...");
        SceneManager.LoadScene("Main_Menu");
    }

    // MENU_OPTIONS

    public void Menu_Pausa_Options() {

        Cursor.visible = true;
        volume.onValueChanged.AddListener(ChangeVolumeMaster);
        fxvolume.onValueChanged.AddListener(ChangeVolumeFX);
        mPausa.SetActive(false);
        mPausa_Options.SetActive(true);
        PlaySoundButton();

    }

    public void Exit_Options(){

        PlaySoundButton();
        mPausa_Options.SetActive(false);
        mPausa.SetActive(true);

    }

    public void SetMute()
    {
        

        if (mute.isOn)
        {
            mixer.GetFloat("VOLMASTER", out lastvolume);

            mixer.SetFloat("VOLMASTER", -80);

        }
        else
        {
            mixer.SetFloat("VOLMASTER", lastvolume);
        }
    }

    public void ChangeVolumeMaster (float v)
    {
    

        mixer.SetFloat("VOLMASTER", v);

    }

    public void ChangeVolumeFX (float v)
    {
        

        mixer.SetFloat("VOLFX", v);

    }

    public void PlaySoundButton()
    {
        fxsource.PlayOneShot(ClickSound);
    }

}

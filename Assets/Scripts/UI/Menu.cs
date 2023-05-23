using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    // Variables of Menu_Pause_Options

    [Header("Options")]
    public Slider volume;
    public Slider fxvolume;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxsource;
    public AudioClip ClickSound;
    private float lastvolume;

    // GameObjects from the differents panels of de principal menu

    [Header("Panels")]
    public GameObject Panel;
    public GameObject Options;
    public GameObject Play_Panel;
    public GameObject Credits;

    private void Start(){

        // Change cursor state

        if(Cursor.visible == false){
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
            mixer.SetFloat("VOLMASTER", 0);

            Time.timeScale = 1f;
        }
    }

    private void awake()
    {
        volume.onValueChanged.AddListener(ChangeVolumeMaster);
        fxvolume.onValueChanged.AddListener(ChangeVolumeFX);
    }

    //Return to main menu
    public void loadPrincipalScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    //Mute control
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

    //Show menu
    public void OpenPanel(GameObject panel) {
        Panel.SetActive(false);
        Options.SetActive(false);
        Play_Panel.SetActive(false);
        Credits.SetActive(false);
        panel.SetActive(true);

        PlaySoundButton();

    }

    //Quit game
    public void ExitGame() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    //Set new main volume
    public void ChangeVolumeMaster (float v)
    {
        mixer.SetFloat("VOLMASTER", v);
    }

    //Set FX volume
    public void ChangeVolumeFX (float v)
    {
        mixer.SetFloat("VOLFX", v);
    }

    //Set click sound
    public void PlaySoundButton()
    {
        fxsource.PlayOneShot(ClickSound);
    }
}

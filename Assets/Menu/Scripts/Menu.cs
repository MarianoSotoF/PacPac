using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [Header("Options")]
    public Slider volume;
    public Slider fxvolume;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxsource;
    public AudioClip ClickSound;
    private float lastvolume;

    [Header("Panels")]
    public GameObject Panel;
    public GameObject Options;
    public GameObject Play_Panel;

    private void Start(){

        // Cambiar el estado del cursor
        if(Cursor.visible == false){

            Cursor.visible = !Cursor.visible;
            Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
            
            Time.timeScale = 1f;
        }
        
        
    }

    private void awake()
    {
        volume.onValueChanged.AddListener(ChangeVolumeMaster);
        fxvolume.onValueChanged.AddListener(ChangeVolumeFX);
    }

    public void loadPrincipalScene(string scene)
    {
        SceneManager.LoadScene(scene);
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

    public void OpenPanel(GameObject panel) {

        Panel.SetActive(false);
        Options.SetActive(false);
        Play_Panel.SetActive(false);
        panel.SetActive(true);

        PlaySoundButton();
    
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

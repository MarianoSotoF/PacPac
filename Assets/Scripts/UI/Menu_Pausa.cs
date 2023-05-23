using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Pausa : MonoBehaviour
{
    //GameObject

    public GameObject player;

    [SerializeField] private GameObject mPausa;
    [SerializeField] private GameObject mPausa_Options;

    // Variables of Menu_Pause_Options

    [Header("Options")]
    public Slider volume;
    public Slider fxvolume;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxsource;
    public AudioClip ClickSound;
    private float lastvolume;

    //Sounds

    public AudioSource sound;

    //Variables
    private bool jPausa = false;

    private void Start() {
        mixer.SetFloat("VOLMASTER", -80);
    }

    private void Update()
    {
        //Detect when menu is selected
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pausa");
            
            if (!jPausa)
            {
                player.SendMessage("LockCamera", true, SendMessageOptions.DontRequireReceiver);
                Pausa();
                mixer.SetFloat("VOLMASTER", 0);         
            }
        }
    }

    //Pause game
    public void Pausa()
    {
        sound.Pause();
        jPausa = true;
        Time.timeScale = 0f;
        mPausa.SetActive(true);
        PlaySoundButton();
    }

    //Resume game
    public void Resume()
    {
        mixer.SetFloat("VOLMASTER", -80);
        sound.Play();
        mPausa.SetActive(false);
        Time.timeScale = 1f;
        jPausa = false;
        player.SendMessage("LockCamera", false, SendMessageOptions.DontRequireReceiver);
    }

    //Restart level
    public void Restart()
    {
        sound.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Exit to main menu
    public void Exit()
    {
        Debug.Log("Volviendo al Menu Principal...");
        SceneManager.LoadScene("Main_Menu");
    }

    // ---------- MENU_OPTIONS ----------

    public void Menu_Pausa_Options(){
        volume.onValueChanged.AddListener(ChangeVolumeMaster);
        fxvolume.onValueChanged.AddListener(ChangeVolumeFX);
        mPausa.SetActive(false);
        mPausa_Options.SetActive(true);
        PlaySoundButton();

    }

    //Exit to menu_pause

    public void Exit_Options(){
        PlaySoundButton();
        mPausa_Options.SetActive(false);
        mPausa.SetActive(true);
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

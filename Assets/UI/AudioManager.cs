using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private AudioSource sfxAudioSource,musicAudioSourse;
    public static AudioManager InstanceMusic;
    [SerializeField]private AudioMixer myMixer;
    [SerializeField]private Slider musicSlider;
    [SerializeField]private Slider SFXSlider;
    
    private void Awake() {
        if(AudioManager.InstanceMusic==null)
        {
             AudioManager.InstanceMusic=this;
             DontDestroyOnLoad(this.gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }
    public void SetMusicVolume()
    {
        float volume=musicSlider.value;
        myMixer.SetFloat("music",Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume",volume);
    }
    public void SetSFXVolume()
    {
        float volume=SFXSlider.value;
        myMixer.SetFloat("SFX",Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SFXVolume",volume);
    }
    private void LoadVolume()
    {
        musicSlider.value=PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value=PlayerPrefs.GetFloat("SFXVolume");
        SetMusicVolume();
        SetSFXVolume();
    }
    private void Start()
    {
         if(PlayerPrefs.HasKey("musicVolume"))
         {
            LoadVolume();
         }else
         {
            SetMusicVolume();
            SetSFXVolume();
            
         }
        
    }

    public void PlaySound(AudioClip clip){
        sfxAudioSource.PlayOneShot(clip);

    }
    public void TogleMusic()
    {
        float currentVolume;
        myMixer.GetFloat("music", out currentVolume); 
        if (currentVolume > -80) 
        {
            myMixer.SetFloat("music", -80); 
        }
        else
        {
            SetMusicVolume(); 
        }
    }
    public void UnmuteMusic()
    {
        SetMusicVolume(); 
    }
}

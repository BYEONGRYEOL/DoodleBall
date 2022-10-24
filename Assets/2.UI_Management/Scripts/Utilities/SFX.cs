using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LineGame;
using LevelManagement.Data;
using Utility;
//SFX only manages sounds that plays only one at a time
public class SFX: SingletonDontDestroyMonobehavior<SFX>
{
    private AudioSource audioSource;
    [SerializeField] public AudioClip audio_Btnclick;
    [SerializeField] public AudioClip audio_Win;
    [SerializeField] public AudioClip audio_Drawing;
    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
        if (DataManager.Instance.Mute)
        {
            Mute();
        }
        Debug.Log("Loading Volume" + DataManager.Instance.SFXVolume);
        Volume(DataManager.Instance.SFXVolume);

    }

    
    public void PlaySFX(string clipName)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        SwitchClip(clipName);
        audioSource.Play();
    }
    private void SwitchClip(string clipName)
    {
        switch (clipName) 
        {
            case "BtnClick":
                audioSource.clip = audio_Btnclick;
                break;
            case "Win":
                audioSource.clip = audio_Win;
                break;
            case "Drawing":
                audioSource.clip = audio_Drawing;
                break;
            case "BtnBackClick":
                //¼öÁ¤°í¹ÎÁß
                audioSource.clip = audio_Btnclick;
                break;
        }
    }
    public void Volume(float vol)
    {
        Debug.Log("Script :: BGM / Function :: Volume");
        audioSource.volume = vol;
    }
    public void UnMute()
    {
        audioSource.mute = false;
        audioSource.Play();
    }
    public void Mute()
    {
        audioSource.mute = true;
        audioSource.Stop();
    }
}

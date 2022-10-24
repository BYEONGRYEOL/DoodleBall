using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LineGame;
using LevelManagement.Data;
using Utility;
public class BGM : SingletonDontDestroyMonobehavior<BGM>
{
    private AudioSource audioSource;
    /*private static BGM instance;
    public static BGM Instance { get { return instance; } }
    private void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }*/
    protected override void Awake()
    {
        base.Awake();
       /* if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        if (Instance == this)
        {
            DontDestroyOnLoad(gameObject);
        }*/
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (DataManager.Instance.Mute)
        {
            Mute();
        }
        Debug.Log("Loading Volume" + DataManager.Instance.MusicVolume);
        Volume(DataManager.Instance.MusicVolume);

    }

    private void Update()
    {
        if (!audioSource.isPlaying && audioSource.mute == false)
        {
            Play();
        }
    }
    public void Play()
    {
        audioSource.Play();
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

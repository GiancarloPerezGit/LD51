using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip mainMenuMusic;


    [SerializeField] private AudioClip clip1;
    [SerializeField] private AudioClip clip2;
    [SerializeField] private AudioClip clip3;
    [SerializeField] private AudioClip clip4;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private AudioClip[] robotClips;
    private bool canPlaySound;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusicWithFade(mainMenuMusic);
        timer = 0.0f;
        canPlaySound = false; 
    }

    // Update is called once per frame
    void Update()
    {
        //every 2 seconds if canPlay is true, play a random robot clip 

        timer += Time.deltaTime; 

        if(timer > 2.0f && canPlaySound)
        {
            PlayRandomRobotVoices(); 
            timer = 0.0f;
        }
    }
    public void PlayClip1() { audioSource.PlayOneShot(clip1); }
    public void PlayClip2() { audioSource.PlayOneShot(clip2); }
    public void PlayClip3() { audioSource.PlayOneShot(clip3); }
    public void PlayClip4() { audioSource.PlayOneShot(clip4); }

    public void SetVolume(float volume) { audioMixer.SetFloat("SFXVol", 20f * Mathf.Log10(SFXSlider.value));  }
    public void SetMusic(float volume ) { audioMixer.SetFloat("MusicVol", 20f * Mathf.Log10(musicSlider.value)); }

    public void PlayRandomRobotVoices()
    {
        //canPlaySound = true;
        Debug.Log("playing a robot sounds");
        audioSource.PlayOneShot(robotClips[Random.Range(0, robotClips.Length)]);
    }

    public void CanPlaySound()
    {
        canPlaySound = true;
        Debug.Log("playin sound");
    }
    public void DontPlaySound()
    {
        canPlaySound = false;
        Debug.Log("no playing sound");
    }

}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading;
using UnityEngine;

public class MechAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip laserBlastclip;
    [SerializeField] AudioClip teleportSound;
    private Controller controller;
    private bool playLeft = false; 
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<Controller>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeterminePlaySide()
    {
        if (controller.activeMechNum == 1 || controller.activeMechNum == 2)
            playLeft = false;
        else
            playLeft = true;
    }

    void RandomizeAudio()
    {
        audioSource.volume = Random.Range(0.85f, 1.0f);
        audioSource.pitch = Random.Range(0.85f, 1.15f);
    }
    public void PlayLaserBlast()
    {
        DeterminePlaySide();
        RandomizeAudio();
        if (playLeft)
            audioSource.panStereo = -0.25f;
        else
            audioSource.panStereo = 0.25f;

        audioSource.PlayOneShot(laserBlastclip); 
    }

    public void PlayTeleportSFX()
    {
        audioSource.PlayOneShot(teleportSound);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFeedbackSFX : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    public AudioClip botCriticalDmg;
    public AudioClip botEnemySpotted;
    public AudioClip botObjLost;
    public AudioClip botOpSuccess;
    public AudioClip botOpWeaponsCharging;

    private float timer = 0.0f;
    private bool canSpeak = false; //delay system so its not spamming words 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;    
        if(timer < 1.25f)
        {
            canSpeak = false; 
        }
        else
        {
            canSpeak = true;
        }
    }

    public void PlayRobotFeedback(AudioClip clip)
    {
        if (!canSpeak) return;
        timer = 0.0f;
        audioSource.PlayOneShot(clip);
    }


}

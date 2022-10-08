using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip flappyDeath;
    [SerializeField] AudioClip basicTankDeath;
    [SerializeField] AudioClip bossTankDeath;

    private bool isPlayLeft; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEnemyDeath(EnemyTypeAudio enemyType, bool playLeft)
    {
        
        if (playLeft)
            audioSource.panStereo = -0.25f;
        else
            audioSource.panStereo = 0.25f;

        RandomizeAudio();

        switch (enemyType)
        {
            case EnemyTypeAudio.FLAPPY_BOT:
                audioSource.PlayOneShot(flappyDeath);
                break;
            case EnemyTypeAudio.BASIC_TANK:
                audioSource.PlayOneShot(basicTankDeath);
                break;
            case EnemyTypeAudio.BOSS_TANK:
                audioSource.PlayOneShot(bossTankDeath);
                break;
        }



       
    }

    void RandomizeAudio()
    {
        audioSource.volume = Random.Range(0.75f, 1.0f);
        audioSource.pitch = Random.Range(0.75f, 1.25f);
    }
}


public enum EnemyTypeAudio
{
    NONE,
    FLAPPY_BOT,
    BASIC_TANK,
    BOSS_TANK
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip gameplayMusic;
    [SerializeField] AudioClip loseA;
    [SerializeField] AudioClip winA;
    [SerializeField] AudioClip loseB;
    [SerializeField] AudioClip winB;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusicWithFade(gameplayMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayLoseLick()
    {
        if (Random.Range(1, 100) % 2 == 0)
        {
            AudioManager.Instance.PlayMusicWithFade(loseA);
        }
        else
            AudioManager.Instance.PlayMusicWithFade(loseB);
    }

    public void PlayWinLick()
    {
        if (Random.Range(1, 100) % 2 == 0)
        {
            AudioManager.Instance.PlayMusicWithFade(winA);
        }
        else
            AudioManager.Instance.PlayMusicWithFade(winB);
    }
}

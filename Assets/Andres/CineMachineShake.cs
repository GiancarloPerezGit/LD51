using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineMachineShake : MonoBehaviour
{

    public static CineMachineShake Instance { get; private set; }

    public float shakeTimer;
    public CinemachineVirtualCamera vcam;

    private void Awake()
    {
        Instance = this;
    }

    public void ShakeCamera(float intensity, float time, CinemachineVirtualCamera cam)
    {
        vcam = cam;

        CinemachineBasicMultiChannelPerlin perlinNoise =
            cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        perlinNoise.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                //Time up
                CinemachineBasicMultiChannelPerlin perlinNoise = 
                    vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                perlinNoise.m_AmplitudeGain = 0f;
            }
        }
    }
}

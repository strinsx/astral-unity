using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeRafales : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float ShakeIntensity = .3f;
    private float ShakeTime = 0.2f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin cmbp;

    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();

    }

    private void Start()
    {
        StopShake();
    }

    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin cmbp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cmbp.m_AmplitudeGain = ShakeIntensity;

        timer = ShakeTime;
    }

    public void JumpSHAKE()
    {
        CinemachineBasicMultiChannelPerlin cmbp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cmbp.m_AmplitudeGain = 0.5f;

        timer = ShakeTime;
    }

    void StopShake()
    {
        CinemachineBasicMultiChannelPerlin cmbp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cmbp.m_AmplitudeGain = 0f;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z)) 
        
        { 
        ShakeCamera();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            JumpSHAKE();

        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if(timer < -0)
            {
                StopShake();
            }
        }
    }
}

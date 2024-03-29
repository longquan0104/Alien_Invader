﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public Camera mainCam;
    float shakeAmount = 0;

    private void Awake()
    {
        if (mainCam == null)
        {
            mainCam = Camera.main;
        }
    }

    public void Shake(float amount, float length)
    {
        shakeAmount = amount;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    private void Update()
    {
        if (mainCam == null)
        {
            mainCam = Camera.main;
        }
    }
    void DoShake()
    {
        if (shakeAmount > 0)
        {
            if (mainCam != null)
            {
                Vector3 camPos = mainCam.transform.position;
                float offSetX = Random.value * shakeAmount * 2 - shakeAmount;
                float offSetY = Random.value * shakeAmount * 2 - shakeAmount;

                camPos.x += offSetX;
                camPos.y += offSetY;

                mainCam.transform.position = camPos;
            }
        }
    }

    void StopShake()
    {
        CancelInvoke("DoShake");
        mainCam.transform.localPosition = Vector3.zero;
    }
}

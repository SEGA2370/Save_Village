// TimeRunner.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class TimeRunner : MonoBehaviour
{
    [SerializeField] private float MaxTime;
    public UnityEvent OnTick;

    private Image progressImage;
    public float currentTime;
    public bool isRunning;

    private void Awake()
    {

        currentTime = 0;
        isRunning = false;
    }


    private void Start()
    {
        progressImage = GetComponent<Image>();
    }

    
    void Update()
    {
        if (isRunning)
        {
            currentTime = Mathf.Max(0, currentTime - Time.deltaTime);

            if (currentTime <= 0)
            {
                currentTime = 0;
                isRunning = false;
                OnTick.Invoke();
            }

            progressImage.fillAmount = currentTime / MaxTime;
        }
    }
    public void Stop()
    {
        isRunning = false;
    }
    public void Restart()
    {
        isRunning = true;
        currentTime = MaxTime;
    }
}

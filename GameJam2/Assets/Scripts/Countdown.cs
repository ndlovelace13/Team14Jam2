using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] private int freeTimeTotal = 60;
    private float currentTime;
    private bool timerActive;
    [SerializeField] private GameObject controller;
    TMPro.TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = freeTimeTotal;
        timerText = GetComponent<TMPro.TMP_Text>();
        timerActive = !controller.GetComponent<GameStateControl>().zombiesAttacking;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            currentTime -= Time.deltaTime;
            updateTimer(currentTime);
        }
        if (currentTime <= 0)
        {
            Debug.Log("The zombies are coming!");
            controller.GetComponent<GameStateControl>().zombiesAttacking = true;
            currentTime = freeTimeTotal;
        }
        timerActive = !controller.GetComponent<GameStateControl>().zombiesAttacking;
    }

    void updateTimer(float time)
    {
        time += 1;

        float seconds = Mathf.FloorToInt(time % freeTimeTotal);
        if (seconds == 0 && timerActive)
        {
            timerText.text = $"{freeTimeTotal}";
        }
        if (seconds == 0 && !timerActive)
        {
            timerText.text = $"The Zombies are Attacking!";
        }
        else
        {
            timerText.text = $"{seconds}";
        }
    }
}

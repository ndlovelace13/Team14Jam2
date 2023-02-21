using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    [SerializeField] private int freeTimeTotal = 60;
    private float currentTime;
    private bool timerActive;
    private bool gameEnd;
    [SerializeField] private GameObject controller;
    TMPro.TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        gameEnd = false;
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
        if (currentTime <= 0 && !gameEnd)
        {
            Debug.Log("The zombies are coming!");
            controller.GetComponent<GameStateControl>().zombiesAttacking = true;
            currentTime = freeTimeTotal;
            timerText.text = $"Germ Invasion!";
        }
        timerActive = !controller.GetComponent<GameStateControl>().zombiesAttacking;
        gameEnd = controller.GetComponent<GameStateControl>().gameEnd;
        if (gameEnd && currentTime <= freeTimeTotal/2)
            timerText.color = Color.red;

        if (gameEnd && currentTime <= 0)
        {
            int y = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(y + 1);
            
        }
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

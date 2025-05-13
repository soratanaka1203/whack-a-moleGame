using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timerText;

    private int score = 0;
    private float timer = 60;
    private bool isGame = false;

    // Start is called before the first frame update
    void Start()
    {
        isGame = true;
        scoreText.text = "SCORE:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (timer < 0)
        {
            Debug.Log("time Up");
        }
        Timer();
    }

    public void AddScore()
    {
        if (isGame)
        {
            score += 100;
            scoreText.text = "SCORE:" + score;
        }
    }

    void Timer()
    {
        if (isGame)
        {
            timer -= Time.deltaTime;
            timerText.text = "TIME:" + timer;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timerText;

    int score = 0;
    float timer = 60;
    bool isGame = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            Debug.Log("time Up");
        }
        timerText.text = "TIME:"+ timer;
    }

    void AddScore()
    {
        if (isGame)
        {
            score += 100;
            scoreText.text = "SCORE:" + score;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI timeUpText;


    private int score = 0;
    private float timer = 60;
    public bool isGame { get; private set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        timeUpText.gameObject.SetActive(false);
        isGame = true;
        scoreText.text = "SCORE:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        TimeUp();
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

    void TimeUp()
    {
        if (timer < 0 && isGame)
        {
            timeUpText.gameObject.SetActive(true);
            isGame = false;
        }
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController gameController;
    public Text Timer;
    public GameObject GameoverText;
    public GameObject RestartBtn;
    public float timeLeft = 30;
    // Use this for initialization

    private void Awake()
    {
        if (gameController == null)                //...set this one to be it...
            gameController = this;
        else
       if (gameController != this)
            //  Destroy(gameObject);
            gameController = this;              // Allowing 2 players

    }
    void Start () {
        Time.timeScale = 1;
        Timer.enabled = true;
        GameoverText.SetActive(false);
    }

    // Update is called once per frame
    

    void Update()
    {
        timeLeft  -=  Time.deltaTime;
        int realtime = (int)timeLeft;
        Timer.text = "Time Left: " + realtime;
        if (timeLeft < 0)
        {
            GameOver();
        }
        if (timeLeft < -1)
        {
            Timer.text = "Time left:" + 0;
        }
    }
    
    public void GameOver()
    {
        GameoverText.SetActive(true);
        RestartBtn.SetActive(true);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}

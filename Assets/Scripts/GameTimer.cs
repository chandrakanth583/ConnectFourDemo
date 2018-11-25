using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO.Ports;

public class GameTimer : MonoBehaviour
{

    //   public Text timerText;
    public Text timeText;
    public Text ballsText;
    public Text scorevalueText;
    public Text creditCountText;

    public GameObject gTimer;
    public GameObject AllBallsText;

    public AudioSource timerAS;
    public AudioClip countdownClip;
    float timeLeft;
    public float maxTime = 30f;

    public int Ballnum = 50;
    public int score = 0;

    public Text scorecal;

    int credits;

    bool timesup = false;

    public GameObject[] balls;

    //  Image TimerFillImage;

    bool isdropppingBall;
    public Image TimerFillImage;
    int i;
    public static SerialPort sp = new SerialPort("COM4", 9600);



    // Use this for initialization
    void Start()
    {
        AllBallsText.SetActive(false);
        scorecal.enabled = false;
        PlayerPrefs.SetInt("ticketcount", 0);
        credits = PlayerPrefs.GetInt("creditcount");
        creditCountText.text = credits.ToString();
        Debug.Log(credits);

        //   sp.Open();
            OpenConnection();
            sp.Write("b");
        Debug.Log("sent   b");
         
        ballsText.text = "BallsLeft : " + Ballnum.ToString();
        scorevalueText.text = score.ToString();
        i = -1;
        maxTime = 30f;
        timeLeft = maxTime;
        timeText.text = timeLeft.ToString();
        isdropppingBall = false;
        Debug.Log("timeleft :" + timeLeft);
        Debug.Log("maxTime :" + maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            credits++;
            creditCountText.text = credits.ToString();
            PlayerPrefs.SetInt("creditcount", credits);
        }
            if (timeLeft <= 10)
        {
            timerAS.PlayOneShot(countdownClip);
        }
        timeLeft -= Time.deltaTime * 0.9f;
        int myTime = (int)(timeLeft);
        timeText.text = myTime.ToString();

        TimerFillImage.fillAmount = timeLeft / maxTime;

        if (score >= 50 && timeLeft > 0)
        {

            //int temp = PlayerPrefs.GetInt("ticketcount");
            //temp = temp + 500;
            //PlayerPrefs.SetInt("ticketcount", 500);
            //PlayerPrefs.Save();
            credits--;
            PlayerPrefs.SetInt("creditcount", credits);
            sendnum();
            sp.Close();
            SceneManager.LoadScene("Jackpot");

        }


        if (Input.GetKeyDown(KeyCode.L))
        {
            score += 1;
            scorevalueText.text = score.ToString();
            PlayerPrefs.SetInt("score", score);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Ballnum -= 1;

            DisableBalls();

            ballsText.text = "BallsLeft :" + Ballnum.ToString();

        }
        //if (Ballnum <= 0)
        //{
        //    sendnum();
        //    sp.Close();

        //    Debug.Log("BallsOver");
        //    //  waitforchange();
           
        //        StartCoroutine(waitforsec());
       



        //}
        if(timeLeft < 0)
        {
            timeText.text = "0";
        } 
        if (timeLeft <= 0 && timesup == false )
        {
            timesup = true;
            timeText.text = "0";
            scorecal.enabled = true;
            credits--;
            PlayerPrefs.SetInt("creditcount", credits);
            
            Debug.Log("timeout");
            sendnum();
            StartCoroutine(waitforsec());
          }

        if(Ballnum <= 0 && timesup == false)
        {
            timesup = true;
            AllBallsText.SetActive(true);
            gTimer.SetActive(false);
            timeText.text = "0";
            scorecal.enabled = true;
            credits--;
            PlayerPrefs.SetInt("creditcount", credits);

            Debug.Log("timeout");
            sendnum();
            StartCoroutine(waitforsec());
        }
        //if (timeLeft < 0)
        //{
        //    timeText.text = "0";
        //}
        if (score >= 0 && score <= 20)
        {

         
            PlayerPrefs.GetInt("ticketcount", 35);
           
        }


        if (score <= 30 && score >= 21)
        {
            PlayerPrefs.GetInt("ticketcount", 45);

          


        }
        if (score <= 39 && score >= 31)
        {
          
            PlayerPrefs.GetInt("ticketcount", 55);
          


        }
        if (score <= 49 && score >= 40)
        {
           
            PlayerPrefs.GetInt("ticketcount", 65);
          
        }
        if (score >= 50)
        {
            
            PlayerPrefs.GetInt("ticketcount", 50);

          


        }

    }
    IEnumerator waitforsec()
    {

        yield return new WaitForSeconds(10f);
        if (score >= 50)
        {
            sendnum();
            sp.Close();
            SceneManager.LoadScene("Jackpot");
        }
        if(score < 50)
        {
            sendnum();
            sp.Close();
            SceneManager.LoadScene("timeout");
        }
    }

   
    public static void sendnum()
    {

        sp.ReadTimeout = 10;
        sp.Write("r");
    }
    void DisableBalls()
    {
        i++;
        balls[i].SetActive(false);

    }

    public void OpenConnection()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                print("Closing port, because it was already open!");
            }
            else
            {
                sp.Open();                                                  // opens the connection
                sp.ReadTimeout = 20;                                        // sets the timeout value before reporting error
                print("Port Opened!");
            }
        }
        else
        {
            if (sp.IsOpen)
            {
                print("Port is already open");
            }
            else
            {
                print("Port == null");
            }
        }

    }

}

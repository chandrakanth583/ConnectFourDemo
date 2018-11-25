using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO.Ports;
using UnityEngine.Video;


public class InsertCoinFromDemo : MonoBehaviour
{

    // Use this for initialization

    public TicketCount scrt;
    public Text ticketmsg;
    int credits;
    public VideoPlayer vidPlayer;

    public bool ismute = false;
    // Update is called once per frame
    public void Start()
    {

        credits = PlayerPrefs.GetInt("creditcount");
        //   Debug.Log(temp.ToString());

    }
    void Update()
    {
        if (ismute == false)
        {
            StartCoroutine(mutevideoplayer());
        }

        if(ismute == true)
        {
            StartCoroutine(unmutevideoplayer());
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            credits += 1;
            PlayerPrefs.SetInt("creditcount", credits);
            SceneManager.LoadScene("game");
           
        }
    }

    IEnumerator mutevideoplayer()
    {
        yield return new WaitForSeconds(30f);
        vidPlayer.SetDirectAudioMute(0, true);
        ismute = true;
    }
    IEnumerator unmutevideoplayer()
    {
        yield return new WaitForSeconds(30f);
        vidPlayer.SetDirectAudioMute(0, false);
        ismute = false;
    }

}

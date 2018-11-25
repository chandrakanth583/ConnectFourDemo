using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TimeoutToTicket : MonoBehaviour
{

    float timeLeft = 5.0f;

    public void Start()
    {
        // ticketdraw.DrawTicket();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            SceneManager.LoadScene("tickets");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using  UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{
    int count;
    public Text waitforsecondplayertext;
    // Use this for initialization
    void Start()

    {
        waitforsecondplayertext.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            count = count + 1;

            StartCoroutine(waitfornextplayer());

        }


        // SceneManager.LoadScene(2);

    }
    IEnumerator waitfornextplayer()
    {
        waitforsecondplayertext.enabled = true;
        yield return new WaitForSeconds(5f);

        if (count == 1)
        {
            SceneManager.LoadScene(1);
        }

        if (count == 2)
        {
            SceneManager.LoadScene(2);
        }
        else if (count >= 2)
        {
            SceneManager.LoadScene(2);
        }
    }

    //  SceneManager.LoadScene(1);


}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToDemo : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(gototickets());
	}
    IEnumerator gototickets()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(5);
    }
	// Update is called once per frame
	void Update ()
    {
		
	}
}

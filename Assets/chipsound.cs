using UnityEngine;
using UnityEngine.Audio;
using System.Collections;


public class chipsound : MonoBehaviour {
    AudioSource auds;
   public AudioClip audclip;

    bool isplayingsound = false;
    private void Start()

    {
    }
    void Update()
    {
        
    }
	void OnCollisionEnter(Collision other){
        //audio.Play();
        auds =  this.GetComponent<AudioSource>();

        this.enabled = true;
        auds = this.GetComponent<AudioSource>();
        
        if (!isplayingsound)

          
        {
            auds.PlayOneShot(audclip);
            // auds.PlayOneShot(audclip);
            isplayingsound = true;
            StartCoroutine(playsoundaftersecs());
            isplayingsound = false;
        }
 }
    IEnumerator playsoundaftersecs()
    {
        yield return new WaitForSeconds(1.0f);
    }
}

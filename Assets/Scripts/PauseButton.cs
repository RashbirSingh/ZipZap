using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {


    public bool paused;
    public Button gameToggleButton;
    public Sprite play;
    public Sprite pause;
    public GameObject countDown;
   // public Animator countDown;


	// Use this for initialization
	void Start () {

        paused = false;
      
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Pause(){

        paused = !paused;

        if(paused){
            Time.timeScale = 0;
            gameToggleButton.GetComponent<Image>().sprite = play;

        }

        else if (!paused)
        {
            gameToggleButton.GetComponent<Image>().sprite = pause;
            Time.timeScale = 1;

        }
    }
}

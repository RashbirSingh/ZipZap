using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControlButton : MonoBehaviour {

    private AudioController music;
    public Button musicToggleButton;
    public Sprite musicON;
    public Sprite musicOFF;


    // Use this for initialization
    void Start()
    {

        music = FindObjectOfType<AudioController>();
        UpdateIcon();

    }

    // Update is called once per frame
    void Update()
    {



    }

    public void PauseMusic()
    {

        music.ToggleSound();
        UpdateIcon();
    }

    public void UpdateIcon()
    {

        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            musicToggleButton.GetComponent<Image>().sprite = musicON;
        }
        else
        {
            AudioListener.volume = 0;
            musicToggleButton.GetComponent<Image>().sprite = musicOFF;
        }

    }


}

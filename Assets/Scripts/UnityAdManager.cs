using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdManager : MonoBehaviour {

    public static UnityAdManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowAd()
    {

        if (PlayerPrefs.HasKey("AdCountZigZag"))
        {

            if (PlayerPrefs.GetInt("AdCountZigZag") == 3)
            {
                //show Add after 3 counts
                if (Advertisement.IsReady("video"))
                {
                    Advertisement.Show("video");
                }
                PlayerPrefs.SetInt("AdCountZigZag", 0);
            }
            else
            {
                PlayerPrefs.SetInt("AdCountZigZag", PlayerPrefs.GetInt("AdCountZigZag") + 1);
            }
        }
        else
        {
            PlayerPrefs.SetInt("AdCountZigZag", 0);
        }
    }

}

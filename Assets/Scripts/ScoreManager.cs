using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {


    public Text currentScore;

    public static ScoreManager instance;
    public int score, highScore;
 

	private void Awake()
	{
        if(instance == null){
            instance = this;
        }
	}
	// Use this for initialization
	void Start () {
        score = 0;
        PlayerPrefs.SetInt("score", score);

	}

    // Update is called once per frame
    void Update()
    {
        currentScore.text = PlayerPrefs.GetInt("score2").ToString();
    }

    public void incrementScore(){
        score += 1;
        PlayerPrefs.SetInt("score2", score);
    }

   public void startScore(){
        InvokeRepeating("incrementScore", 0.1f, 0.5f);
       
    }


    public void stopScore(){
        CancelInvoke("incrementScore");
        PlayerPrefs.SetInt("score", score);
        int A = PlayerPrefs.GetInt("score");
        int B = PlayerPrefs.GetInt("Diamond");
        PlayerPrefs.SetInt("TotalScore", A+(2*B));
        int C = PlayerPrefs.GetInt("TotalScore");
        if(PlayerPrefs.HasKey("highScore")){
            if(C > PlayerPrefs.GetInt("highScore")){
                PlayerPrefs.SetInt("highScore", C);
            }
        }
        else{
            PlayerPrefs.SetInt("highScore", C);
        }
    }
}

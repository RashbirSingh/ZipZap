using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {





    public static UIManager instance;
    public GameObject StartPanel;
    public GameObject gameOverPanel;
    public GameObject Panel;
    public GameObject TapText;
    public Text score;
    public Text HighestScore1;
    public Text HighestScore2;
    public Text DiamondsScore;
    public Text TotalScore;


	private void Awake()
	{
        if(instance == null){
            instance = this;
        }
	}
	// Use this for initialization
	void Start () {
        HighestScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(false);
        Panel.SetActive(false);
	}
    public void gameStart(){
        //TapText.SetActive(false);
        TapText.GetComponent<Animator>().Play("TextDown");
        StartPanel.GetComponent<Animator>().Play("PanelAnimation");
        gameOverPanel.SetActive(false);
        Panel.SetActive(false);
    }

    public void gameOver(){
        
        score.text = PlayerPrefs.GetInt("score").ToString();
        HighestScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
        Panel.SetActive(true);
        Panel.GetComponent<Animator>().Play("EndPanelAnimation");
        DiamondsScore.text = (2 * PlayerPrefs.GetInt("Diamond")).ToString();
        TotalScore.text = (PlayerPrefs.GetInt("score") + 2 * PlayerPrefs.GetInt("Diamond")).ToString();
        
    }

	public void Reset()
	{
        SceneManager.LoadScene("Level1");
       // PlayerPrefs.SetInt("score2", 0);
      //  PlayerPrefs.SetInt("Diamond", 0);
	}

    public void MenuMain()
    {
        SceneManager.LoadScene(0);
        // PlayerPrefs.SetInt("score2", 0);
        //  PlayerPrefs.SetInt("Diamond", 0);
    }



	// Update is called once per frame
	void Update () {
        
	}
}

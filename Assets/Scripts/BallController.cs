using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallController : MonoBehaviour
{

    public AudioSource DiamondCollision;
    //int Score;
    int Diamond = 0;
    public Text diamond;
    public Text TimeText; // time  text UI
    private float startTime; //time initialization
    bool TimeGate = true; 
    bool TimeGateOpen = false;


    public GameObject particle;
    public GameObject two; // plus two +2 object
    private float StratTime;
    [SerializeField]
    private float speed = 5;
    bool started, GameOver;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        started = false; // game started?
        GameOver = false; // game over?
        startTime = Time.time; // time initialized
        Diamond = 1; // setting diamond count
        DiamondCollision = GetComponent<AudioSource>(); // audio when ball and diamond collide
      
    }

    // Update is called once per frame
    void Update()
    {

        //Score = PlayerPrefs.GetInt("score");
        diamond.text = "X " + PlayerPrefs.GetInt("Diamond").ToString(); // image field(diamond) X diamond count from player pref "Diamond"

        if (!started) // If game is not started then
        {
            if (Input.GetMouseButtonDown(0)) // on screen press, on single tap
            {
                rb.velocity = new Vector3(speed, 0, 0); // initial speed in direction X
                started = true; // true, game has started
                GameOver = false; // false, game is not over
                GameManager.instance.startGame(); // game manager instiance called to start game
                TimeGateOpen = true; // time gate open, time count srarted from 00:00:00
            }
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1f) && !GameOver)
        {
            rb.velocity = new Vector3(0, -25f, 0);
            GameOver = true;
            GameManager.instance.gameOver();
            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            //   GetComponent<PlatformSpawnner>().gameOver = true;
            TimeGate = false;
            Diamond = 1;

        }
        if (Input.GetMouseButtonDown(0) && !GameOver)
        {

            SwitchDirection();
            speed += 1 * Time.deltaTime; // speed increases with time speed = speed + 1 * time.deltatime, with each tap(Change in direction) speed increases with the multiple of time

        }

        if (TimeGate == true && TimeGateOpen == true)  // time calling, if game srated then start counting time 
        {
            TimeFunction();
        }

    }
   
    void TimeFunction(){   // time function to display time
        
        float t = Time.time - startTime; 
        string minute = ((int)t / 60).ToString(); //converting inr to string type using.ToString();
        string seconds = (t % 60).ToString("f2");// f2 shows the decimal place for mili second f2 means 2 decimal places i.e 00:00:((00)) <- ((00)) is the mili second place id set f4 then ((0000))
        TimeText.text = "Time: " + minute + ":" + seconds; // time text UI Time: minutes(00) + " : " seconds(00:f2)
    
    }

    void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0); // // change in direction when tapped is velocity is in z direction
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed); // change in direction when tapped is velocity is in x direction
        }
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "Diamond")
        {
            GameObject part = Instantiate(particle, other.gameObject.transform.position, Quaternion.identity) as GameObject;
            GameObject twoo = Instantiate(two, other.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            DiamondCollision.Play();
            Destroy(part, 1f);
            Destroy(twoo, 1f);
            PlayerPrefs.SetInt("Diamond", Diamond++); //OnTriggerEnter collision diamond playor pref +1

        }
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour {

    public GameObject ball;
    public Vector3 offset;
    public float lurpRate;
    public bool gameOver;
    // Use this for initialization
    void Start()
    {
        offset = ball.transform.position - transform.position;
        gameOver = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameOver)
        {
            follow();
        }
    }

    void follow()
    {
        Vector3 pos = transform.position;
        Vector3 target = ball.transform.position - offset;
        //pos = Vector3.Lerp(pos, target, lurpRate * Time.deltaTime);
        pos = Vector3.Lerp(pos, target, lurpRate);
        transform.position = pos;
    }
}

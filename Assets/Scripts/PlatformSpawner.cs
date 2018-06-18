using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformSpawner : MonoBehaviour {

    public GameObject platform;
    public GameObject diamond;
    Vector3 lastPos;
    float sizeX, sizeZ;
    public bool gameOver;

	// Use this for initialization
	void Start () {

        gameOver = false;
        lastPos = platform.transform.position;
        sizeX = platform.transform.localScale.x;
        sizeZ = platform.transform.localScale.z;


	}

    public void StartSpawningPlatform(){
        InvokeRepeating("spawnPlatform", 0.3f, 0.2f);
    }
	
	// Update is called once per frame
	void Update () {
        if(GameManager.instance.GameOver == true){
            CancelInvoke("spawnPlatform");
        }

	}

    void spawnPlatform(){

        int rand = (int) Random.Range(0, 6);

        if (rand < 3){
            spwanX();
        }
        else if ( rand >= 3){
            spwanZ();
        }

    }

    void spwanX() {

        Vector3 pos = lastPos;
        pos.x += sizeX;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = (int)Random.Range(0, 4);
        if(rand < 1){
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
        
    }

    void spwanZ() {

        Vector3 pos = lastPos;
        pos.z += sizeZ;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = (int) Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
        
    }

}

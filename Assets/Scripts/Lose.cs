using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose : MonoBehaviour {

    public Text lose;
    public static float loseScore;
    public float time;
    public Text score;
    

    // Use this for initialization
    void Start () {
        score.enabled = false;
        lose.enabled = false;
        time = EconomyScript.timer;
        loseScore = 1;
        Debug.Log("loseScore Start = " + loseScore);
    }
	
	// Update is called once per frame
	void Update () {
        time = EconomyScript.timer;
		if(loseScore == 0 ) 
        {
            Debug.Log("works");
            Time.timeScale = 0;
            score.text ="Your Score:" + time.ToString("0.0");
            lose.enabled = true;
            score.enabled = true;
        }
	}
}

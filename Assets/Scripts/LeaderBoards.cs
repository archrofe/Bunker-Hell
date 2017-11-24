using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoards : MonoBehaviour {
    public float curHighScore;
    public float reset;
    public float highTime;
    public float topScore;
    public float secScore;
    public float thirScore;
    public float tempSecScore;
    public float tempThirScore;
    public Text firstPlace;
    public Text secPlace;
    public Text thirPlace;
    public Text highPlace;

    // Use this for initialization
    void Start () {
        curHighScore = PlayerPrefs.GetFloat("1st Place");
        highPlace.text = "H i g h s c o r e : " + curHighScore.ToString("0 . 0");
        reset = 0;
        // 1st place
        topScore = PlayerPrefs.GetFloat("1st Place");
        firstPlace.text = "1 s t  P l a c e   T i m e : " + topScore.ToString("0 . 0");
        // 2nd place
        secScore = PlayerPrefs.GetFloat("2nd Place");
        secPlace.text = "2 n d  P l a c e  T i m e : " + secScore.ToString("0 . 0");
        tempSecScore = PlayerPrefs.GetFloat("1st Place");
        // 3rd place
        thirScore = PlayerPrefs.GetFloat("3rd Place");
        thirPlace.text = "3 r d  P l a c e  T i m e : " + thirScore.ToString("0 . 0");
        tempThirScore = PlayerPrefs.GetFloat("2nd Place");
    }
	
	// Update is called once per frame
	void Update () {
        highTime = Lose.time;
        CheckScore();
    }

    public void CheckScore()
    {
        if(highTime > topScore)
        {
            
            secPlace.text = "2 n d  P l a c e  T i m e : " + tempSecScore.ToString("0 . 0 ");
            PlayerPrefs.SetFloat("2nd Place", tempSecScore);
            thirPlace.text = "3 r d  P l a c e  T i m e : " + tempThirScore.ToString("0 . 0 ");
            PlayerPrefs.SetFloat("3rd Place", tempThirScore);

            topScore = highTime;
            firstPlace.text = "1 s t  P l a c e  T i m e : " + highTime.ToString("0 . 0");
            PlayerPrefs.SetFloat("1st Place", highTime);

        }

        if (highTime > secScore && highTime < topScore)
        {
            thirPlace.text = "3 r d  P l a c e  T i m e : " + tempThirScore.ToString("0 . 0 ");
            PlayerPrefs.SetFloat("3rd Place", tempThirScore);

            secScore = highTime;
            secPlace.text = "2 n d  P l a c e  T i m e : " + highTime.ToString("0 . 0");
            PlayerPrefs.SetFloat("2nd Place", highTime);
        }

        if (highTime > thirScore && highTime < secScore && highTime < topScore)
        {
            thirScore = highTime;
            thirPlace.text = "3 r d  P l a c e  T i m e : " + highTime.ToString("0 . 0");
            PlayerPrefs.SetFloat("3rd Place", highTime);
        }
    }
}

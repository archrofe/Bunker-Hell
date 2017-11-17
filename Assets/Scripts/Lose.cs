using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{

    public Text lose;
    public static float loseScore;
    public static float time;
    public Text score;
    public Image bGround;
    public bool lost;

    // Use this for initialization
    void Start()
    {
        lost = false;
        bGround.enabled = false;
        score.enabled = false;
        lose.enabled = false;
        time = EconomyScript.timer;
        loseScore = 1;
        Debug.Log("loseScore Start = " + loseScore);
    }

    // Update is called once per frame
    void Update()
    {
        
        time = EconomyScript.timer;
        if (loseScore == 0)
        {
            //Debug.Log("works");
            StartCoroutine(BackToMain());
            score.text = "Your Time: " + time.ToString("0.0");
            lose.enabled = true;
            score.enabled = true;
            bGround.enabled = true;
            loseScore = 1;
            
        }
    }

    IEnumerator BackToMain()
    {
        Debug.Log("Before");

        yield return new WaitForSeconds(2);

        Debug.Log("After");

        SceneManager.LoadScene("Menu");
    }
}

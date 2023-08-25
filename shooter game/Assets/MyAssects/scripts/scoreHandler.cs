using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreHandler : MonoBehaviour
{
    TMP_Text scoreText;

    int score;

    void Start()
    {
        scoreText =GetComponent<TMP_Text>();
        scoreText.text =" start";
    }
    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        //Debug.Log($"the score is : {score}");

        scoreText.text = score.ToString();
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score = 0;

    public void IncreaseScore(int amountToIncerase)
    {
        score += amountToIncerase;
    }

    public void ShowScore()
    {
        Debug.Log($"Points scored: {score}");
    }
}

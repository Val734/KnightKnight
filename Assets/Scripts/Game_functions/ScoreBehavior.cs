using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreBehavior : MonoBehaviour
{
    public int score;
    public UnityEvent<int> OnChangeScore;
    public UnityEvent OpenDoor;

    private void OnEnable()
    {
        ScoreUpdater.OnUpdateScore += AddScore;
    }

    private void OnDisable()
    {
        ScoreUpdater.OnUpdateScore -= AddScore;
    }

    private void Start()
    {
        score = 0;
    }

    public void AddScore(int d)
    {
        score += d;
        OnChangeScore.Invoke(score);
        
        if(score==4)
        {
            OpenDoor.Invoke();
        }
    }

    public void ResetScore()
    {
        score = 0;
        OnChangeScore.Invoke(score);
    }
}

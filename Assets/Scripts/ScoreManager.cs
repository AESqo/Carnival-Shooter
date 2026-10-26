using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour{
    public static ScoreManager Instance { get; private set; }
    public static event Action<int> OnScoreChanged;
    private int currentScore = 0;
    private void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    public void NotifyTargetHit(int points) {
        currentScore += points;      
        OnScoreChanged?.Invoke(currentScore);
    }
}

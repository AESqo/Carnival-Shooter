using UnityEngine;
using TMPro; 

public class ScoreUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI scoreText;
    private void OnEnable() {
        ScoreManager.OnScoreChanged += UpdateScoreDisplay;
    }
    private void OnDisable() {
        ScoreManager.OnScoreChanged -= UpdateScoreDisplay;
    }
    private void UpdateScoreDisplay(int newScore) {
        if (scoreText != null) {
            scoreText.text = $"Score: {newScore}";
        }
    }
}

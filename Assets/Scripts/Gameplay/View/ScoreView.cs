using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _scoreText;

    private void OnEnable() {
        _scoreCounter.UpdateScore += OnScoreUpdate;
    }

    private void OnDisable() {
        _scoreCounter.UpdateScore -= OnScoreUpdate;
    }

    public void Show() {
        _scoreText.text = "0";
    }

    public void Hide() {
        _scoreText.text = "";
    }

    private void OnScoreUpdate(int newScore) {
        _scoreText.text = newScore.ToString();
    }
}

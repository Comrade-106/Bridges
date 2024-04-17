using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField] private BlockPositionValidator _positionValidator;
    [SerializeField] private CanvasGroup _gameOverWindow;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private ScoreView _scoreView;

    private void OnEnable() {
        _positionValidator.GameOver += Open;
    }

    private void OnDisable() {
        _positionValidator.GameOver -= Open;
    }

    public void Open() {
        _gameOverWindow.alpha = 1;
        _gameOverWindow.interactable = true;
        _scoreText.text = "Score: " + _scoreCounter.Score.ToString();
        _scoreView.Hide();
    }

    public void OnRestartButtonClick() {
        SceneManager.LoadScene(0);
    }
}

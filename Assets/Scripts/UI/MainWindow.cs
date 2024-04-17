using System;
using UnityEngine;

public class MainWindow : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private CanvasGroup _mainCanvas;
    [SerializeField] private ScoreView _scoreView;

    private bool _isClosed = false;

    private void Update() {
        if (_isClosed) return;

        if (Input.GetMouseButtonDown(0)) {
            _game.StartNewGame();
            Close();
            _scoreView.Show();
            _isClosed = true;
        }
    }

    public void Close() {
        _mainCanvas.alpha = 0;
        _mainCanvas.interactable = false;
    }

    public void Open() {
        _mainCanvas.alpha = 1;
        _mainCanvas.interactable = true;
    }
}

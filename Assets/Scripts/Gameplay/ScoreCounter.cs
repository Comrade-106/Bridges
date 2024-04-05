using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private float _epsilon;

    private int _score;

    private UnityEvent<int> _updateScore;

    public int Score {
        get => _score; 
    }

    public event UnityAction<int> UpdateScore {
        add => _updateScore?.AddListener(value);
        remove => _updateScore?.RemoveListener(value);
    }

    private void Awake() {
        Debug.Log("Awake");
        _updateScore = new UnityEvent<int>();
    }

    public void AddScore(Block block1, Block block2) {
        _score += (Mathf.Abs(block1.transform.position.y - block2.transform.position.y) <= _epsilon) ? 2 : 1;

        _updateScore.Invoke(_score);
    }
}

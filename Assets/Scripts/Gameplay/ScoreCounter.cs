using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    private UnityEvent<int> _updateScore;

    public event UnityAction<int> UpdateScore {
        add => _updateScore?.AddListener(value);
        remove => _updateScore?.RemoveListener(value);
    }

    public void AddScore(Block block1, Block block2) {
        _score += block1.transform.position.y == block2.transform.position.y ? 2 : 1;

        _updateScore?.Invoke(_score);
    }
}

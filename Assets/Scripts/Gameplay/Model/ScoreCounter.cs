using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private float _epsilon;
    [SerializeField] private AudioClip _goodSound;
    [SerializeField] private AudioClip _perfectSound;
    [SerializeField] private AudioSource _audioSource;

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
        _updateScore = new UnityEvent<int>();
    }

    public void AddScore(Block block1, Block block2) {
        if (Mathf.Abs(block1.transform.position.y - block2.transform.position.y) <= _epsilon)
            AddScore(2, _perfectSound);
        else
            AddScore(1, _goodSound);
    }

    private void AddScore(int score, AudioClip clip) {
        _score += score;
        _audioSource.PlayOneShot(clip);

        _updateScore.Invoke(_score);
    }
}

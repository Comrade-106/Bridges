using UnityEngine;
using UnityEngine.Events;

public class BlockPositionValidator : MonoBehaviour
{
    [SerializeField] private float _blockSize;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private MapBounds _mapBounds;
    [SerializeField] private AudioClip _gameOverSound;
    [SerializeField] private AudioSource _audioSource;

    private Block _previousBlock;
    private UnityEvent _gameOver;
    private UnityEvent _gameFinish;
    private UnityEvent _blockApprove;

    public event UnityAction GameOver {
        add => _gameOver.AddListener(value);
        remove => _gameOver.RemoveListener(value);
    }

    public event UnityAction GameFinish {
        add => _gameFinish.AddListener(value);
        remove => _gameFinish.RemoveListener(value);
    }

    public event UnityAction BlockApprove {
        add => _blockApprove.AddListener(value);
        remove => _blockApprove.RemoveListener(value);
    }

    private void Awake() {
        _blockApprove = new UnityEvent();
        _gameOver = new UnityEvent();
        _gameFinish = new UnityEvent();
    }

    private void OnEnable() {
        _mapBounds.BlockTouchBounds += OnBlockTouchBounds;
    }

    private void OnDisable() {
        _mapBounds.BlockTouchBounds -= OnBlockTouchBounds;
    }

    private void OnBlockTouchBounds() {
        Debug.Log("Bounds");
        _gameOver?.Invoke();
    }

    public void Initialize(Block startBlock) {
        _previousBlock = startBlock;
    }

    public void SubscribeToStopBlockEvent(Block block) {
        block.BlockStopped += OnBlockStop;
    }

    private void OnBlockStop(Block block) {
        if(_previousBlock.transform.position.y >= block.transform.position.y &&
            _previousBlock.transform.position.y - _blockSize < block.transform.position.y) {
            _scoreCounter.AddScore(_previousBlock, block);
            _previousBlock = block;
            block.BlockStopped -= OnBlockStop;

            _blockApprove?.Invoke();
        } else {
            _audioSource.PlayOneShot(_gameOverSound);
            _gameOver?.Invoke();
        }
    }

    public void ValidateFinishBlock(Block block) {
        if (_previousBlock.transform.position.y + _blockSize > block.transform.position.y &&
             _previousBlock.transform.position.y - _blockSize < block.transform.position.y) {
            _scoreCounter.AddScore(_previousBlock, block);
            
            _gameFinish?.Invoke();
        } else {
            _audioSource.PlayOneShot(_gameOverSound);
            _gameOver?.Invoke();
        }
    }
}

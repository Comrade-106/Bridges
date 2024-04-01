using UnityEngine;
using UnityEngine.Events;

public class BlockPositionValidator : MonoBehaviour
{
    [SerializeField] private float _blockSize;
    [SerializeField] private ScoreCounter _scoreCounter;

    private Block _previousBlock;
    private UnityEvent<int> _gameOver;
    private UnityEvent<int> _gameFinish;
    private UnityEvent _blockApprove;

    public event UnityAction<int> GameOver {
        add => _gameOver.AddListener(value);
        remove => _gameOver.RemoveListener(value);
    }

    public event UnityAction<int> GameFinish {
        add => _gameFinish.AddListener(value);
        remove => _gameFinish.RemoveListener(value);
    }

    public event UnityAction BlockApprove {
        add => _blockApprove.AddListener(value);
        remove => _blockApprove.RemoveListener(value);
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
            _gameOver?.Invoke(_scoreCounter.Score);
        }
    }

    public void ValidateFinishBlock(Block block) {
        if (_previousBlock.transform.position.y + _blockSize > block.transform.position.y &&
             _previousBlock.transform.position.y - _blockSize < block.transform.position.y) {
            _scoreCounter.AddScore(_previousBlock, block);

            _gameFinish?.Invoke(_scoreCounter.Score);
        } else {
            _gameOver?.Invoke(_scoreCounter.Score);
        }
    }
}

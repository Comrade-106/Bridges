using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private BlockPositionValidator _blockPositionValidator;
    [SerializeField] private BlockSpawner _blockSpawner;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private BlockTrackingCamera _blockTrackingCamera;
    [SerializeField] private float _blockSize;
    [SerializeField] private float _yOffset;

    private Level _currentLevel;
    private int _currentBlockNumber = 1;

    private void OnEnable() {
        _blockPositionValidator.BlockApprove += OnBlockApprove;
    }

    private void OnDisable() {
        _blockPositionValidator.BlockApprove -= OnBlockApprove;
    }

    public void StartNewGame() {
        _currentLevel = _levelGenerator.GenerateNewLevel();
        _blockPositionValidator.Initialize(_currentLevel.StartBlock);
        _blockTrackingCamera.DoStartAnimation(_currentLevel.FinishBlock, RunNextBlock);
    }

    private void OnBlockApprove() {
        RunNextBlock();
    }

    private void RunNextBlock() {
        if(_currentBlockNumber >= _currentLevel.BlockCount) {
            _blockPositionValidator.ValidateFinishBlock(_currentLevel.FinishBlock);
            return;
        }

        var side = Random.Range(0f, 1f) <= 0.5f ? Side.Down : Side.Up;

        var block = _blockSpawner.SpawnBlock(side);
        block.transform.position = GetStartPosition(side);
        _blockPositionValidator.SubscribeToStopBlockEvent(block);
        _blockTrackingCamera.UpdateViewForBlock(block);

        _currentBlockNumber++;
    }

    private Vector3 GetStartPosition(Side side) {
        var x = _blockSize * _currentBlockNumber;
        var y = side == Side.Up ? _yOffset : -_yOffset;

        return new Vector3(x, y, 0);
    }

}

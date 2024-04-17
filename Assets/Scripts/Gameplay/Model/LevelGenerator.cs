using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private float _blockWidht;
    [SerializeField] private float _maxYOffset;
    [SerializeField] private int _minBlockCount;
    [SerializeField] private int _maxBlockCount;
    [SerializeField] private BlockSpawner _blockSpawner;

    public Level GenerateNewLevel() {
        int blockCount = Random.Range(_minBlockCount, _maxBlockCount);

        var startBlock = _blockSpawner.SpawnStaticBlock();
        startBlock.transform.position = Vector3.zero;

        var finishBlock = _blockSpawner.SpawnStaticBlock();
        finishBlock.transform.position = new Vector3(blockCount * _blockWidht, -Random.Range(0, _maxYOffset), 0);

        return new Level(startBlock, finishBlock, blockCount);
    }
}

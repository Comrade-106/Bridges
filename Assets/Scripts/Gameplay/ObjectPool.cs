using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Block _prefab;

    private Queue<Block> _blocks;
    private Queue<Block> _activeBlocks;

    private void Awake() {
        _blocks = new Queue<Block>();
        _activeBlocks = new Queue<Block>();
    }

    public Block GetBlock() {
        Block block;
        if (_blocks.Count == 0) {
            block = Instantiate(_prefab, _container);
            _activeBlocks.Enqueue(block);
        } else {
            block = _blocks.Dequeue();
        }

        return block;
    }
}

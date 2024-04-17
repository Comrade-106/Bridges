using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
	[SerializeField] private float _minSpeed;
	[SerializeField] private float _maxSpeed;

    private ObjectPool _pool;

    private void Awake() {
        _pool = GetComponent<ObjectPool>();
    }

    public void HideAllBlocks() {
        _pool.PutAllBlockInPull();
    }

    public Block SpawnBlock(Side side) {
        var block = _pool.GetBlock();
        ConfigureBlock(block, side);

        return block;
    }

    public Block SpawnStaticBlock() {
        var block = _pool.GetBlock();
        block.Initialize(_colors[Random.Range(0, _colors.Length - 1)]);

        return block;
    }

    private void ConfigureBlock(Block block, Side side) {
        var speed = Random.Range(_minSpeed, _maxSpeed);
        var color = _colors[Random.Range(0, _colors.Length - 1)];
        var direction = side == Side.Up ? Vector2.down : Vector2.up;

        block.Initialize(direction, speed, color);
    }
}

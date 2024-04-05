using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    private float _speed;
    private Vector2 _direction;
    private SpriteRenderer _spriteRenderer;
    private bool _isStoped; 
    private UnityEvent<Block> _blockStopped;

    public event UnityAction<Block> BlockStopped {
        add => _blockStopped.AddListener(value);
        remove => _blockStopped.RemoveListener(value);
    }

    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _blockStopped = new UnityEvent<Block>();
    }

    public void Initialize(Vector2 direction, float speed, Color color) {
        _speed = speed;
        _direction = direction;
        _spriteRenderer.color = color;
    }

    public void Initialize(Color color) {
        _spriteRenderer.color = color;
        _isStoped = true;
    }

    private void Update() {
        if (_isStoped)
            return;

        if (Input.GetMouseButtonDown(0)) {
            _isStoped = true;
            _blockStopped?.Invoke(this);
            return;
        }

        float moveY = _direction.y * _speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x, transform.position.y + moveY);
    }
}

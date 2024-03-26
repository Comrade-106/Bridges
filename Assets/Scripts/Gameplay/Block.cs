using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;
    private Vector2 _direction;
    private bool _isStoped;

    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Initialize(Vector2 direction, Color color) {
        _direction = direction;
        _spriteRenderer.color = color;
    }

    private void Update() {
        if (_isStoped)
            return;

        if (Input.GetMouseButtonDown(0)) {
            _isStoped = true;
            return;
        }

        float moveY = _direction.y * _speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x, transform.position.y + moveY);
    }
}

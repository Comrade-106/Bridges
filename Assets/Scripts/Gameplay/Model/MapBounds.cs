using UnityEngine;
using UnityEngine.Events;

public class MapBounds : MonoBehaviour
{
    private UnityEvent _blockTouchBounds;

    public event UnityAction BlockTouchBounds {
        add => _blockTouchBounds?.AddListener(value);
        remove => _blockTouchBounds?.RemoveListener(value);
    }

    private void Awake() {
        _blockTouchBounds = new UnityEvent();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.TryGetComponent<Block>(out Block block)) {
            _blockTouchBounds?.Invoke();
        }
    }
}

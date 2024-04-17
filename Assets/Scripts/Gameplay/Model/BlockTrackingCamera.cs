using UnityEngine;
using DG.Tweening;
using System;

[RequireComponent(typeof(Camera))]
public class BlockTrackingCamera : MonoBehaviour
{
    [SerializeField] private float _animationTime;

    private Camera _camera;
    private Vector3 _startPosition;

    private readonly Vector3 _center = new Vector3(0.5f, 0.5f, 0.5f);

    private void Awake() {
        _camera = GetComponent<Camera>();
        _startPosition = transform.position;
    }

    public void DoStartAnimation(Block finishBlock, Action OnCompliteAction = null) {
        transform.position = _startPosition;
        float startX = _camera.transform.position.x;
        Sequence mySequence = DOTween.Sequence();

        mySequence.AppendInterval(1f);
        mySequence.Append(transform.DOMoveX(finishBlock.transform.position.x, _animationTime));
        mySequence.AppendInterval(1f);
        mySequence.Append(transform.DOMoveX(startX, _animationTime));

        mySequence.OnComplete(() => OnCompliteAction?.Invoke());
    }

    public void UpdateViewForBlock(Block block) {
        Vector3 viewportPosition = _camera.WorldToViewportPoint(block.gameObject.transform.position);

        if(viewportPosition.x > _center.x) {
            var newPosition = _camera.transform.position;
            newPosition.x = block.transform.position.x;

            _camera.transform.position = newPosition;
        }
    }
}

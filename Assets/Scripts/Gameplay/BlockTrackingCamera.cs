using UnityEngine;

[RequireComponent(typeof(Camera))]
public class BlockTrackingCamera : MonoBehaviour
{
    private Camera _camera;

    private readonly Vector3 _center = new Vector3(0.5f, 0.5f, 0.5f);

    private void Awake() {
        _camera = GetComponent<Camera>();
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

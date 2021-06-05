using UnityEngine;

public class CharacterLookToMouse : MonoBehaviour {
    private Camera _camera;
    private void Awake() {
        _camera = Camera.main;
    }
    private void Update() {
        var position = transform.position;
        var plane = new Plane(Vector3.up, position);
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out float enter)) {
            var point = ray.GetPoint(enter);
            var direction = point - position;
            var angle = Vector3.SignedAngle(Vector3.forward, direction, Vector3.up);
            transform.eulerAngles = new Vector3(0f, angle, 0f);
        }
    }
}

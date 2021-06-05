using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour {
    private Rigidbody _rigidbody;
    private Vector2 _input;
    private Camera _camera;
    public float speed = 4f;
    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }
    private void Update() {
        _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _input = Vector2.ClampMagnitude(_input, 1f);
    }
    private void FixedUpdate() {
        var cameraTransform = _camera.transform;
        var forward = cameraTransform.forward;
        forward.y = 0;
        forward = forward.normalized;
        
        var right = cameraTransform.right;
        right.y = 0;
        right = right.normalized;
        
        var movement = (_input.y * speed * forward) + (_input.x * speed * right);
        movement.y = _rigidbody.velocity.y;
        _rigidbody.velocity = movement;
    }
}

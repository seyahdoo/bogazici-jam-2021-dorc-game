using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bot : MonoBehaviour {
    public float stoppingDistance;
    public float speed;
    private bool _following;
    private Transform _target;
    private Rigidbody _rigidbody;
    private void Awake() {
        var player = FindObjectOfType<CharacterMovement>();
        _target = player.transform;
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update() {
        if (_following) {
            var position = transform.position;
            var point = _target.position;
            var direction = point - position;
            direction.y = 0f;
            var angle = Vector3.SignedAngle(Vector3.forward, direction, Vector3.up);
            transform.eulerAngles = new Vector3(0f, angle, 0f);
        }
        if (_following) {
            var position = transform.position;
            var point = _target.position;
            var difference = point - position;
            var distance = difference.magnitude;
            if (distance > stoppingDistance) {
                var desiredVelocity = difference;
                desiredVelocity.y = 0f;
                desiredVelocity = desiredVelocity.normalized;
                desiredVelocity *= speed;
                _rigidbody.velocity = new Vector3(desiredVelocity.x, _rigidbody.velocity.y, desiredVelocity.z);
            }
        }
    }
    public void StartFollowing() {
        _following = true;
        _rigidbody.isKinematic = false;
    }
}

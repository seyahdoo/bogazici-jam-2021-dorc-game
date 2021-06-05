using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAttack : MonoBehaviour {
    public GameObject hitBox;
    public float hitActiveDuration = 1f;

    private Animator _animator;
    private float _hitEndTime;
    private bool _hitting;
    private static readonly int AttackStateHash = Animator.StringToHash("Attack");
    private void Awake() {
        hitBox.SetActive(false);
        _hitting = false;
        _hitEndTime = Time.time;
        _animator = GetComponent<Animator>();
    }
    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            _hitting = true;
            _hitEndTime = Time.time + hitActiveDuration;
            hitBox.SetActive(true);
            _animator.SetTrigger(AttackStateHash);
        }
        if (_hitting && Time.time > _hitEndTime) {
            _hitting = false;
            hitBox.SetActive(false);
        }
    }
}

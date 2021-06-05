using UnityEngine;

public class CharacterAttack : MonoBehaviour {
    public GameObject hitBox;
    public float hitActiveDuration = 1f;

    private float _hitEndTime;
    private bool _hittting;
    private void Awake() {
        hitBox.SetActive(false);
        _hittting = false;
        _hitEndTime = Time.time;
    }
    private void Update() {
        if (Input.GetButton("Fire1")) {
            _hittting = true;
            _hitEndTime = Time.time + hitActiveDuration;
            hitBox.SetActive(true);
        }
        if (_hittting && Time.time > _hitEndTime) {
            _hittting = false;
            hitBox.SetActive(false);
        }
    }
}

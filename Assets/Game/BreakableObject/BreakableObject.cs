using System;
using UnityEngine;

public class BreakableObject : MonoBehaviour {
    public GameObject normalVersion;
    public GameObject brokenVersion;
    private bool _broken;
    private void Awake() {
        _broken = false;
        normalVersion.SetActive(true);
        brokenVersion.SetActive(false);
    }
    public void Break() {
        if (_broken) return;
        _broken = true;
        brokenVersion.transform.position = normalVersion.transform.position;
        brokenVersion.transform.rotation = normalVersion.transform.rotation;
        normalVersion.SetActive(false);
        brokenVersion.SetActive(true);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("CharacterHitBox")) {
            Break();
        }
    }
}

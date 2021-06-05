using UnityEngine;

public class LightBot : Bot {
    public GameObject openObjects;
    public GameObject closedObjects;
    private bool _open;
    private void Awake() {
        _open = true;
        ToggleLight();
    }
    public void ToggleLight() {
        _open = !_open;
        if(openObjects != null) openObjects.SetActive(_open);
        if(closedObjects != null) closedObjects.SetActive(!_open);
    }
    public bool Open => _open;
}

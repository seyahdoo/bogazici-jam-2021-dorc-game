using System;
using UnityEngine;

public class ButtonBot : Bot {
    public delegate void OnPressedDelegate(ButtonBot button);
    public event OnPressedDelegate OnPressed;
    private void OnTriggerEnter(Collider other) {
        OnPressed?.Invoke(this);
    }
}

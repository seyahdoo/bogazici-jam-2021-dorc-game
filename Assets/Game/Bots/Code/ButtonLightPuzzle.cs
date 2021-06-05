using System.Collections.Generic;
using UnityEngine;

public class ButtonLightPuzzle : MonoBehaviour {
    public List<ButtonBot> buttons = new List<ButtonBot>();
    public List<LightBot> lights = new List<LightBot>();
    public int[][] buttonsToLightsMap = new[] {
        new[] {0, 1},
        new[] {1, 2},
        new[] {2}
    };
    private void Awake() {
        foreach (var button in buttons) {
            button.OnPressed += ButtonOnOnPressed;
        }
    }
    private void ButtonOnOnPressed(ButtonBot button) {
        var index = buttons.IndexOf(button);
        var lightIndexesToToggle = buttonsToLightsMap[index];
        foreach (var i in lightIndexesToToggle) {
            lights[i].ToggleLight();
        }
    }
}

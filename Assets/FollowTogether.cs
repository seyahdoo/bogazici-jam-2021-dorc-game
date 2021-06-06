using System.Collections.Generic;
using UnityEngine;

public class FollowTogether : MonoBehaviour {
    public List<Bot> bots;
    private bool _triggered = false;
    private void Awake() {
        foreach (var bot in bots) {
            bot.OnStartFollowing += OnStartFollowing;
        }
    }
    private void OnStartFollowing() {
        if (_triggered) return;
        _triggered = true;
        foreach (var bot in bots) {
            bot.StartFollowing();
        }
    }
}

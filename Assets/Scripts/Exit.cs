using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public bool IsOpen { get; set; }

    private void Start() {
        LevelManager.Instance.AddExit(this);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (IsOpen) {
            LevelManager.Instance.LoadNextLevel();
        }
    }
}

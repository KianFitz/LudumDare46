using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private void Start() {
        LevelManager.Instance.AddGem(this);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        LevelManager.Instance.RemoveGem(this);
        Destroy(gameObject);
    }
}

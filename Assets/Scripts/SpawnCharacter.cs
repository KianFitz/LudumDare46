using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    [SerializeField]
    private GameObject character;

    private void Start() {
        Instantiate(character);
    }


}

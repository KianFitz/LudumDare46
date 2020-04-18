using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static LevelManager Instance { get; private set; }

    [SerializeField]
    private string nextLevel;
    [SerializeField]
    private GameObject exit;
    [SerializeField]
    private List<Gem> gems;

    private void Awake() {
        Instance = this;
    }

    public void AddGem(Gem gem) {
        gems.Add(gem);
    }

    public void RemoveGem(Gem gem) {

        Instance.gems.Remove(gem);

        if (Instance.gems.Count == 0) {
            // Open the exit
            Debug.Log("Collected all the gems");
        }
    }

    public void LoadNextLevel() {
        SceneManager.LoadScene(nextLevel);
    }

}

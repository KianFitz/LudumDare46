using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static LevelManager Instance { get; private set; }

    [SerializeField]
    private string nextLevel;
    [SerializeField]
    private List<Gem> gems;

    private Exit exit;

    private void Awake() {
        Instance = this;
    }

    public void AddGem(Gem gem) {
        gems.Add(gem);
    }

    public void RemoveGem(Gem gem) {

        gems.Remove(gem);

        if (Instance.gems.Count == 0) {
            // Open the exit
            Debug.Log("Collected all the gems");
            exit.IsOpen = true;
        }
    }

    public void LoadNextLevel() {
        SceneManager.LoadScene(nextLevel);
    }

    public void AddExit(Exit exit) {
        if (this.exit != null) {
            Debug.LogError("There are two exits you idiot");
            return;
        }

        this.exit = exit;
    }
}

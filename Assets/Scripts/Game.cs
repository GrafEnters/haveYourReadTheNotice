using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {
    [SerializeField]
    private string _sceneNameOnAgree;

    [SerializeField]
    private AntivirusModule _antivirusModulePrefab;

    public Action OnJump;

    private void Awake() {
        Cat cat = FindObjectOfType<Cat>();
        if (cat != null) {
            cat.Init(Win, delegate { OnJump?.Invoke(); });
        }
    }

    private void Start() {
        InitParameters(GameParametersManager.Instance.GameParameters);
    }

    private void InitParameters(GameParameters parameters) {
        if (parameters.IsAntivirusActive) {
            AntivirusModule antivirusModule = Instantiate(_antivirusModulePrefab);
            antivirusModule.Init(this);
        }
    }

    public void Win() {
        SceneManager.LoadScene(_sceneNameOnAgree);
    }
}
using System;
using UnityEngine;

namespace DefaultNamespace {
    public class GameParametersManager : MonoBehaviour {
        public static GameParametersManager Instance;

        [SerializeField]
        private GameParameters _gameParameters = new GameParameters();

        public GameParameters GameParameters => _gameParameters;

        public void Awake() {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                OnFirstInit();
            } else {
                Destroy(gameObject);
            }
        }

        private void OnFirstInit() { }
    }
}
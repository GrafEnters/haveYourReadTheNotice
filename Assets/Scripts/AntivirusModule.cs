using System;
using UnityEngine;

namespace DefaultNamespace {
    public class AntivirusModule : GameModule {
        private Game _game;
        private Cat _player;
        private Canvas _canvas;

        [SerializeField]
        private AntivirusPopup _antivirusPopup;

        public void Init(Game game) {
            _game = game;
            Subscribe();
            _player = FindObjectOfType<Cat>();
            _canvas = FindObjectOfType<Canvas>();
        }

        private void Subscribe() {
            _game.OnJump += ShowAntivirus;
        }

        private void UnSubscribe() {
            _game.OnJump -= ShowAntivirus;
        }

        private void ShowAntivirus() {
            Debug.Log("Antivirus shown!");
            Vector3 rectPos = Camera.main.WorldToScreenPoint(_player.transform.position);
            Instantiate(_antivirusPopup, rectPos, Quaternion.identity, _canvas.transform);
        }

        private void OnDestroy() {
            UnSubscribe();
        }
    }
}
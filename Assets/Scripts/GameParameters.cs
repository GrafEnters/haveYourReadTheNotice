using UnityEngine;

namespace DefaultNamespace {
    [System.Serializable]
    public class GameParameters {
        public bool IsAntivirusActive;



        public void ChangeParameter(ParameterName name, object data) {
            switch (name) {
                case ParameterName.IsAntivirusActive:
                    IsAntivirusActive = (bool)data;
                    return;
                default:
                    Debug.LogError("ChangeParameter error!");
                    return;
            }
            
        }
    }


    public enum ParameterName {
        IsAntivirusActive
    }
}
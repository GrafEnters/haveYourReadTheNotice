using UnityEngine;

namespace DefaultNamespace {
    public class ToggleParameter : MonoBehaviour {
        [SerializeField]
        private ParameterName _fieldName;

        public void Start() {
            Toggle(transform.GetComponentInChildren<UnityEngine.UI.Toggle>().isOn);
        }

        public void Toggle(bool isOn) {
            GameParametersManager.Instance.GameParameters.ChangeParameter(_fieldName, isOn);
        }
    }
}
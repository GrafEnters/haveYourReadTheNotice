using UnityEngine;
using UnityEngine.SceneManagement;

public class Notice : MonoBehaviour{
    [SerializeField] private string _sceneNameOnAgree;

    private bool IsConditionsMet(){
        return true;
    }

    public void Agree(){
        if (IsConditionsMet()){
            SceneManager.LoadScene(_sceneNameOnAgree);
        }
        else{
            ShowErrorHint();
        }
    }

    private void ShowErrorHint(){ }
}
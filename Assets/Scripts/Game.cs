using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour{
    [SerializeField] private string _sceneNameOnAgree;

    private void Awake(){
        Cat cat = FindObjectOfType<Cat>();
        if (cat != null){
            cat.Init(Win);
        }
    }

    public void Win(){
        SceneManager.LoadScene(_sceneNameOnAgree);
    }
}
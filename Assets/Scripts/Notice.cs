using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Notice : MonoBehaviour{
    [SerializeField] private string _sceneNameOnAgree;
    [SerializeField] private NoticeConfig _noticeConfig;
    [SerializeField] private List<TextMeshProUGUI> _texts;

    private void Awake(){
        SetTexts();
    }

    private void SetTexts(){
        for (int index = 0; index < _noticeConfig.Texts.Count; index++){
            string textData = _noticeConfig.Texts[index];
            _texts[index].text = textData;
        }
    }

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
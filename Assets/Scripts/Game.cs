using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
   [SerializeField] private string _sceneNameOnAgree;
   public void Win()
   {
      SceneManager.LoadScene(_sceneNameOnAgree);
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeSceneByName_test(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
        
    }
}

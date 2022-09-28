using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    [SerializeField] string _sceneName;

    public void LoadNextScene(string sceneName)
    {
        Debug.Log($"UI�������ꂽ��{_sceneName}�ڍs");
        SceneManager.LoadScene(_sceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField] string _sceneName;

    public void MoveTitle()
    {
        Debug.Log("�V�[������");
        SceneManager.LoadScene(_sceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���{�҂��Ǘ�����
/// </summary>
public class PlaySceneManager : MonoBehaviour
{
    /// <summary>���̍ő吔</summary>
    [SerializeField] int _maxKeyCount;
    /// <summary>���݂̌��̌�</summary>
    int CurrentKeyCount { get; set; }
    public int _countCey => CurrentKeyCount;


void Awake()
    {
        CurrentKeyCount = 0;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void CeyCount()
    {
        CurrentKeyCount++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountKeyCanvas : MonoBehaviour
{
    [Tooltip("�擾�������̃J�E���g")]
    [SerializeField] RectTransform _countKey;
    [Tooltip("���̃C���X�g")]
    [SerializeField] Sprite _keysprite;
    [Tooltip("�Q�[�����̃V�[���}�l�[�W���[")]
    [SerializeField] PlaySceneManager playscene;
    [Tooltip("���̃J�E���g���h�A�֌�������\������e�L�X�g")]
    [SerializeField] Text _keytext;
    [Tooltip("�\�����錮�̃C���X�g")]
    [SerializeField] Vector2 _keyScale = new Vector2(50f,50f);
    // Start is called before the first frame update
    void Start()
    {
        Count();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>������������ɌĂяo���֐�</summary>
    public void KeyCount()
    {
        Count();
        if(playscene._countCey >= 5)
        {
            _keytext.text = "�h�A�֌������I";
        }
    }

    /// <summary>����������J�E���g���ăe�L�X�g��C���X�g��\������֐��B</summary>
    void Count()
    {
        _keytext.text = ($"����{ 5 - playscene._countCey}�I");
        foreach (Transform i in _countKey)
        {
            Destroy(i.gameObject);
        }
        for(var i = 0;i < playscene._countCey; i++)
        {
            GameObject gmobj = new GameObject();
            Image image = gmobj.AddComponent<Image>();

            image.sprite = _keysprite;

            RectTransform rect = gmobj.GetComponent<RectTransform>();
            rect.sizeDelta = _keyScale;
            gmobj.transform.SetParent(_countKey);
        }
    }
}

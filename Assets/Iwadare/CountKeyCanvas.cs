using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountKeyCanvas : MonoBehaviour
{
    [SerializeField] RectTransform _countKey;
    [SerializeField] Sprite _keysprite;
    [SerializeField]PlaySceneManager playscene;
    [SerializeField] Text _keytext;
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

    public void KeyCount()
    {
        Count();
        if(playscene._countCey >= 5)
        {
            _keytext.text = "�h�A�֌������I";
        }
    }

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

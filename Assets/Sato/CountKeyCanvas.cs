using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountKeyCanvas : MonoBehaviour
{
    [Tooltip("取得した鍵のカウント")]
    [SerializeField] RectTransform _countKey;
    [Tooltip("鍵のイラスト")]
    [SerializeField] Sprite _keysprite;
    [Tooltip("ゲーム内のシーンマネージャー")]
    [SerializeField] PlaySceneManager playscene;
    [Tooltip("鍵のカウント＆ドアへ向かえを表示するテキスト")]
    [SerializeField] Text _keytext;
    [Tooltip("表示する鍵のイラスト")]
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
    /// <summary>鍵を取った時に呼び出す関数</summary>
    public void KeyCount()
    {
        Count();
        if(playscene._countCey >= 5)
        {
            _keytext.text = "ドアへ向かえ！";
        }
    }

    /// <summary>取った鍵をカウントしてテキストやイラストを表示する関数。</summary>
    void Count()
    {
        _keytext.text = ($"あと{ 5 - playscene._countCey}つ！");
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Tooltip("移動するポイント")]
    [SerializeField] Transform[] _targets;
    [Tooltip("スピード")]
    [SerializeField] float _speed = 3f;
    [Tooltip("移動する場所が変わるまでの時間(今回は使用してない)")]
    [SerializeField] float _stopDis = 0.05f;
    [Tooltip("ポイント移動するときに使う変数")]
    int _targetIndex = 0;
    [SerializeField] Vector3 dir;
    [Tooltip("敵に当たった時ワープする位置")]
    GameObject _warpMazzle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
        //Flip(dir.x, dir.y);
    }

    /// <summary>騎士がポイント間を移動する関数。</summary>
    void Patrol()
    {
        float distance = Vector2.Distance(transform.position, _targets[_targetIndex].position);

        if (distance > _stopDis)
        {
            dir = (_targets[_targetIndex].transform.position - transform.position).normalized * _speed;
            transform.Translate(dir * Time.deltaTime);
        }
        else
        {
            _targetIndex++;
            _targetIndex = _targetIndex % _targets.Length;
        }
    }
    /// <summary>プレイヤーに当たったらプレイヤーを_warpMazzleまでワープさせる</summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _warpMazzle = GameObject.FindGameObjectWithTag("Warp");
            collision.transform.position = _warpMazzle.transform.position;
        }
    }
}

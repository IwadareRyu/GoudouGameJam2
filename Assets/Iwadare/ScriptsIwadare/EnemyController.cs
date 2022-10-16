using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Tooltip("�ړ�����|�C���g")]
    [SerializeField] Transform[] _targets;
    [Tooltip("�X�s�[�h")]
    [SerializeField] float _speed = 3f;
    [Tooltip("�ړ�����ꏊ���ς��܂ł̎���(����͎g�p���ĂȂ�)")]
    [SerializeField] float _stopDis = 0.05f;
    [Tooltip("�|�C���g�ړ�����Ƃ��Ɏg���ϐ�")]
    int _targetIndex = 0;
    [SerializeField] Vector3 dir;
    [Tooltip("�G�ɓ������������[�v����ʒu")]
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

    /// <summary>�R�m���|�C���g�Ԃ��ړ�����֐��B</summary>
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
    /// <summary>�v���C���[�ɓ���������v���C���[��_warpMazzle�܂Ń��[�v������</summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _warpMazzle = GameObject.FindGameObjectWithTag("Warp");
            collision.transform.position = _warpMazzle.transform.position;
        }
    }
}

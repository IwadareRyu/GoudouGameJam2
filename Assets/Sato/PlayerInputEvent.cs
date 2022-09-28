using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���͂���������v���C���[���C�x���g���N����
/// </summary>
public class PlayerInputEvent : MonoBehaviour
{
    /// <summary>���C���q�b�g���郌�C���[</summary>
    [SerializeField] LayerMask _mask;
    /// <summary>���C�̒���</summary>
    [SerializeField] int _rayDist;
    /// <summary>�C�x���g���q�b�g�����Ƃ��̃}�[�N</summary>
    [SerializeField] GameObject _hitMark;

    /// <summary>���C���΂�����</summary>
    public Vector3 RayDir { get; set; }


    void Start()
    {
        
    }

    void Update()
    {
        // �w�肳�ꂽ������Ray���΂�
        RaycastHit2D hit = Physics2D.Raycast(transform.position, RayDir.normalized, _rayDist, _mask);
        if (hit.collider != null)
        {
            if (_hitMark.activeSelf == false) _hitMark.SetActive(true);
            if (Input.GetButtonDown("Submit"))
            {
                Debug.Log("�C�x���g���s");
            }
        }
        else
        {
            if (_hitMark.activeSelf == true) _hitMark.SetActive(false);
        }
    }
}

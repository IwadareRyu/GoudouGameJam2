using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̈ړ��𐧌䂷��
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D _rb;
    PlayerInputEvent _pie;
    /// <summary>�v���C���[�̈ړ����x�̔{��</summary>
    [SerializeField] float _speedMag;
    /// <summary>���鑬�x�̔{��</summary>
    [SerializeField] float _dashMag;
    /// <summary>�c��</summary>
    [SerializeField] GameObject[] _afterEffects;
    /// <summary>�v���C���[�̉摜�̃A�j���[�^�[</summary>
    Animator _spriteAnim;
    /// <summary>���͂��ꂽ�ړ��x�N�g��</summary>
    Vector3 _velocity;
    /// <summary>�O�t���[���̈ړ��x�N�g��</summary>
    Vector3 _prevVelo;
    /// <summary>�_�b�V�����Ă��邩�ǂ���</summary>
    bool _dash = false;
    /// <summary>�c�����o���܂ł̃J�E���g</summary>
    float _afterEffectCount;
    /// <summary>�o���c���̔ԍ�</summary>
    int _afterEffectIndex;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _pie = GetComponent<PlayerInputEvent>();
        _spriteAnim = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        _dash = Input.GetKey(KeyCode.LeftShift);

        _velocity = new Vector3(hori, vert, 0);

        if (_dash)
        {
            _spriteAnim.speed = _dashMag;

            _afterEffectCount += Time.deltaTime;
            if(_afterEffectCount > 0.1)
            {
                _afterEffectCount = 0;
                Instantiate(_afterEffects[_afterEffectIndex], transform.position, Quaternion.identity);
            }
        }
        else
        {
            _spriteAnim.speed = 1;
            _afterEffectCount = 0;
        }




        if (_prevVelo != _velocity)
        {
            if (hori == -1)
            {
                _spriteAnim.Play("Left");
                _pie.RayDir = -transform.right;
                _afterEffectIndex = 3;
            }
            else if (hori == 1)
            {
                _spriteAnim.Play("Right");
                _pie.RayDir = transform.right;
                _afterEffectIndex = 2;
            }
            else if (vert == 1)
            {
                _spriteAnim.Play("Up");
                _pie.RayDir = transform.up;
                _afterEffectIndex = 1;
            }
            else if (vert == -1)
            {
                _spriteAnim.Play("Down");
                _pie.RayDir = -transform.up;
                _afterEffectIndex = 0;
            }
        }

        _prevVelo = _velocity;
    }

    void FixedUpdate()
    {
        _rb.velocity = _velocity * _speedMag * (_dash ? _dashMag : 1);
    }
}

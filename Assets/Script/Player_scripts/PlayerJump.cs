using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public static PlayerJump instance;
    private Rigidbody2D _myBody;
    private Animator _anim;
    private float _forceX, _forceY;
    private float _tresholdX = 7.0f;
    private float _tresholdY = 14.0f;
    private bool _setPower, _didJump;

    void Awake()
    {
        MakeInstance();
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void SetPower(bool _setPower)
    {
        this._setPower = _setPower;
        if (_setPower)
        {
            Debug.Log("We are setting power");
        }
        else
        {

            Debug.Log("We are not setting power");
        }

    }
}

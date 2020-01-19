using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public static PlayerJump instance;
    private Rigidbody2D _myBody;
    private Animator _anim;
    [SerializeField]
    private float _forceX, _forceY;
    private float _tresholdX = 7.0f;
    private float _tresholdY = 14.0f;
    private bool _setPower, _didJump;

    void Awake()
    {
        MakeInstance();
        Initialize();
    }
    private void Update()
    {
        SetPower();
    }
    
    void Initialize(){
        _myBody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void SetPower()
    {
        if (_setPower)
        {
            _forceX += _tresholdX * Time.deltaTime;
            _forceY += _tresholdY * Time.deltaTime;
            if (_forceX > 6.5f)
            {
                _forceX = 6.5f;
            }
            if (_forceY > 13.0f)
            {
                _forceY = 13.0f;
            }
        }
    }
    public void SetPower(bool _setPower)
    {
        this._setPower = _setPower;
        if (!_setPower)
        {
            Jump();
        }

    }
    void Jump()
    {
        _myBody.velocity = new Vector2(_forceX, _forceY);
        _forceX = _forceY = 0;
        _didJump = true;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(_didJump){
_didJump = false;
        }
        if(other.tag == "Platform"){
if(GameManager.instance != null){
GameManager.instance.CreateNewPlatformAndLerp(other.transform.position.x);
}
        }
    }
}

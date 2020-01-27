using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private Slider _powerSlider;
    private float _powerBarTreshold = 14f;
    private float _powerBarValue = 0f;
    void Awake()
    {
        MakeInstance();
        Initialize();
    }
    private void Update()
    {
        SetPower();
    }

    void Initialize()
    {
        _powerSlider = GameObject.Find("PowerBar").GetComponent<Slider>();
        _myBody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _powerSlider.minValue = 0f;
        _powerSlider.maxValue = 10f;
        _powerSlider.value = _powerBarValue;
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
            _powerBarValue += _powerBarTreshold * Time.deltaTime;
            _powerSlider.value = _powerBarValue;
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
        _anim.SetBool("Jump", _didJump);
        _powerBarValue = 0f;
        _powerSlider.value = _powerBarValue;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (_didJump)
        {
            _didJump = false;
            _anim.SetBool("Jump", _didJump);
        }
        if (other.tag == "Platform")
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.CreateNewPlatformAndLerp(other.transform.position.x);
            }
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.IncrementScore();
            }
        }

        if (other.tag == "Death")
        {
            Debug.Log("Coll" + " " + other.tag);
            if (GameOverManager.instance != null)
            {
                GameOverManager.instance.GameOverShowPanel();
                Debug.Log("DeathTrigger");
            }
            Destroy(gameObject);
        }
    }
}

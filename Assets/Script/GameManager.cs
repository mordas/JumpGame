using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _platform;
    private float _minX = -2.1f, _maxX = 2.1f, _minY = -4.7f, _maxY = -3.7f;
    private bool _lerpCamera;
    private float _lerpTime = 1.5f;
    private float _lerpX;



    private void Awake()
    {
        MakeInstance();
        CreateInitialPlatforms();
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Update() {
        if(_lerpCamera){
            LerpCamera();
        }
    }
    void CreateInitialPlatforms()
    {
        Vector3 temp = new Vector3(Random.Range(_minX, _minX + 1.2f), Random.Range(_minY, _maxY), 0);
        Instantiate(_platform, temp, Quaternion.identity);
        temp.y += 2.0f;
        Instantiate(_player, temp, Quaternion.identity);
        temp = new Vector3(Random.Range(_maxX, _maxX - 1.2f), Random.Range(_minY, _maxY), 0);
        Instantiate(_platform, temp, Quaternion.identity);
    }
    public void CreateNewPlatformAndLerp(float lerpPosition)
    {
        CreateNewPlatform();
        _lerpX = lerpPosition + _maxX;
        _lerpCamera = true;
    }
    void CreateNewPlatform()
    {
        float _cameraX = Camera.main.transform.position.x;
        float _newMaxX = (_maxX * 2) + _cameraX;
        Vector3 temp = new Vector3(Random.Range(_newMaxX, _newMaxX - 1.2f), Random.Range(_maxY, _maxY - 1.2f), 0);
        Instantiate(_platform, temp, Quaternion.identity);
    }

    void LerpCamera()
    {
        Transform _camera = Camera.main.transform;
        float x = _camera.position.x;
        x = Mathf.Lerp(x, _lerpX, _lerpTime * Time.deltaTime);
        _camera.position = new Vector3(x, _camera.position.y, _camera.position.z);
        if (_camera.position.x >= (_lerpX - 0.07f))
        {
            _lerpCamera = false;
        }
    }
}

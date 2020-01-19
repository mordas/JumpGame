using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _platform;
    private float _minX = -2.5f, _maxX = 2.5f, _minY = -4.7f, _maxY = -3.7f;



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
    void CreateInitialPlatforms()
    {
        Vector3 temp = new Vector3(Random.Range(_minX, _minX + 1.2f), Random.Range(_minY, _maxY), 0);
        Instantiate(_platform, temp, Quaternion.identity);
        temp.y += 2.0f;
        Instantiate(_player, temp, Quaternion.identity);
        temp = new Vector3(Random.Range(_maxX, _maxX - 1.2f), Random.Range(_minY, _maxY), 0);
        Instantiate(_platform, temp, Quaternion.identity);
    }
}

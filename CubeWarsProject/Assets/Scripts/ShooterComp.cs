using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterComp : MonoBehaviour
{
    [SerializeField]
    private Transform _spawnPoint;

    [SerializeField]
    private int _damange;

    [SerializeField]
    private GameObject _bullet;

    public void Fire()
    {
        Instantiate(_bullet, _spawnPoint);
    }
}

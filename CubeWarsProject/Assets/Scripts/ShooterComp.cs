using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterComp : MonoBehaviour
{
    [SerializeField]
    protected Transform _spawnPoint;

    [SerializeField]
    protected Transform _headAxisPoint;

    [SerializeField]
    protected int _damange;

    [SerializeField]
    protected GameObject _bullet;
    protected float _heightPoint;


    private void Awake()
    {
        _heightPoint = _headAxisPoint.position.y;
    }

    public void Fire()
    {
        Instantiate(_bullet, _spawnPoint.position, _spawnPoint.rotation);
    }

    public void LookAtUnit(Transform target)
    {
        Vector3 pos = target.position;
        pos.y = _heightPoint;
        pos -= _headAxisPoint.position;
        _headAxisPoint.transform.rotation = Quaternion.LookRotation(pos, Vector3.up);
    }
}

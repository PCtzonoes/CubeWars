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
    protected float _fireRate = 3;

    [SerializeField]
    protected GameObject _bullet;
    [SerializeField]
    protected BulletLayer _origin = BulletLayer.ProjectileEnemies;

    protected float _heightPoint;
    private float _timer;


    public enum BulletLayer
    {
        ProjectileEnemies = 9,
        ProjectilePlayer = 11
    }

    protected virtual void Awake()
    {
        _heightPoint = _headAxisPoint.position.y;
        _timer = Time.time;
    }


    public virtual void Fire()
    {
        if (_timer + _fireRate < Time.time)
        {
            GameObject temp = Instantiate(_bullet, _spawnPoint.position, _spawnPoint.rotation);
            temp.layer = (int)_origin;
            _timer = Time.time;
        }
    }

    public void FireOnMove(Vector3 velocity)
    {
        if (_timer + _fireRate < Time.time)
        {
            Bullet bullet = Instantiate(_bullet, _spawnPoint.position, _spawnPoint.rotation).GetComponent<Bullet>();
            bullet.AddVelocity(velocity);
            bullet.gameObject.layer = (int)_origin;
            _timer = Time.time;
        }
    }

    public void LookAtUnit(Transform target)
    {
        Vector3 pos = target.position;
        pos.y = _heightPoint;
        pos -= _headAxisPoint.position;
        _headAxisPoint.transform.rotation = Quaternion.LookRotation(pos, Vector3.up);
    }
}

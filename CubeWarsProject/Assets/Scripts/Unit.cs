using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ShooterComp))]
public abstract class Unit : MonoBehaviour
{

    [SerializeField]
    protected int _life = 100;

    [SerializeField]
    protected float _moveSpeed = 5;
    protected bool _alive = true;

    protected ShooterComp _sc;

    protected virtual void Awake()
    {
        _sc = GetComponent<ShooterComp>();
    }

    public virtual void ApplyDamange(int amount)
    {
        _life -= amount;
        if (_life <= 0)
        {
            Death();
            _life = 0;
        }
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ShooterComp))]
public abstract class Unit : MonoBehaviour
{

    [SerializeField]
    protected int _life = 100;

    [SerializeField]
    protected float _moveSpeed = 5;

    protected Rigidbody _rigidBody;
    protected ShooterComp _sc;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _sc = GetComponent<ShooterComp>();
    }

    public void ApplyDamange(int amount)
    {
        _life -= amount;
        if (amount <= 0) Death();
    }

    protected virtual void Death()
    {
        throw new NotImplementedException();
    }
}

using UnityEngine;

[RequireComponent(typeof(LifeSpan))]
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int _damange = 10;
    [SerializeField]
    private float _moveSpeed = 8;

    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.velocity = transform.forward * _moveSpeed;
    }

    public void SetDamange(int amount)
    {
        if (amount > 0) _damange = amount;
    }



    private void OnCollisionEnter(Collision other)
    {
        Unit otherUnit = other.gameObject.GetComponent<Unit>();
        if (otherUnit != null)
        {
            otherUnit.ApplyDamange(_damange);
        }
    }
}

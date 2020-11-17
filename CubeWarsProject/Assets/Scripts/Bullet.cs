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

    public void AddVelocity(Vector3 vel)
    {
        _rigidBody.velocity += vel * 0.35f;
        if (_rigidBody.velocity.magnitude < _moveSpeed)
        {
            _rigidBody.velocity *= 1.5f;
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        Unit otherUnit = other.gameObject.GetComponentInParent<Unit>();
        if (otherUnit != null)
        {
            otherUnit.ApplyDamange(_damange);
            Destroy(gameObject);
        }
    }
}

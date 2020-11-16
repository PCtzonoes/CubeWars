using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : Unit
{


    public static Player PlayerUnit;

    private float _inputX;
    private float _inputZ;


    [SerializeField]
    private Transform _targetPoint;
    public Transform TargetPoint { get => _targetPoint; }

    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        PlayerUnit = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _sc.Fire();
        }

        ReadInput();
    }


    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector3(_inputX * _moveSpeed,
         _rigidBody.velocity.y, _inputZ * _moveSpeed);
    }


    private void ReadInput()
    {
        _inputX = Input.GetAxis("Horizontal");
        _inputZ = Input.GetAxis("Vertical");
    }
}

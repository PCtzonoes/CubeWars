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


    protected override void Awake()
    {
        _sc = GetComponent<ShooterComp>();
        _rigidBody = GetComponent<Rigidbody>();
        PlayerUnit = this;
    }

    private void Start()
    {
        GameManager.singleton.UpdateHealthPoints(_life);
    }

    private void Update()
    {
        if (_alive)
        {
            PlayerShoot();
            ReadInput();
        }
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector3(_inputX * _moveSpeed,
         _rigidBody.velocity.y, _inputZ * _moveSpeed);
    }

    private void PlayerShoot()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _sc.FireOnMove(_rigidBody.velocity);
        }
    }

    private void ReadInput()
    {
        _inputX = Input.GetAxis("Horizontal");
        _inputZ = Input.GetAxis("Vertical");
    }

    public override void ApplyDamange(int amount)
    {
        base.ApplyDamange(amount);
        GameManager.singleton.UpdateHealthPoints(_life);
    }

    protected override void Death()
    {
        if (_alive)
        {
            Time.timeScale = 0.1f;
            _alive = false;
            GameManager.singleton.GameLose();
        }
    }
}

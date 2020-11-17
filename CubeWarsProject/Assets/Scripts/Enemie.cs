using UnityEngine;


public class Enemie : Unit
{
    public static int EnemiesCount = 0;

    [SerializeField]
    private int _points = 5;
    [SerializeField]
    private float _deathSpeed = 5;
    [SerializeField]
    private Collider _collider;

    private float timer;
    private Transform target;


    private void Start()
    {
        target = Player.PlayerUnit.TargetPoint;
        EnemiesCount++;
    }

    private void Update()
    {
        if (_alive)
            _sc.LookAtUnit(target);
    }

    private void FixedUpdate()
    {
        if (_alive)
            ShootPlayer();
    }

    private void ShootPlayer()
    {
        _sc.Fire();
    }

    protected override void Death()
    {
        if (_alive)
        {
            _alive = false;
            EnemiesCount--;
            if (EnemiesCount == 0)
            {
                GameManager.singleton.Victory();
            }
            GameManager.singleton.UpdateScore(_points);
            DeathAnim();
        }
    }

    public static void ResetEnemieCount()
    {
        EnemiesCount = 0;
    }

    private void DeathAnim()
    {
        if (_alive == false)
        {
            gameObject.layer = 0;
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            _collider.enabled = true;
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rb.useGravity = true;
            rb.velocity = ((transform.position - target.position).normalized * 2.5f);
            rb.velocity = new Vector3(rb.velocity.x, _deathSpeed, rb.velocity.z);
            Destroy(gameObject, 4);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
    }
}

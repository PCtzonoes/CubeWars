using UnityEngine;

public class Enemie : Unit
{
    public static int EnemiesCount = 0;

    [SerializeField]
    private int _points = 5;


    private float timer;
    private Transform target;


    private void Start()
    {
        target = Player.PlayerUnit.TargetPoint;
        EnemiesCount++;
    }

    private void Update()
    {
        _sc.LookAtUnit(target);
    }

    private void FixedUpdate()
    {
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
            base.Death();
        }
    }

    public static void ResetEnemieCount()
    {
        EnemiesCount = 0;
    }
}

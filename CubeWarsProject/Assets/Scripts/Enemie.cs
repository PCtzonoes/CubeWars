using UnityEngine;

public class Enemie : Unit
{
    [SerializeField]
    private int _points = 5;
    [SerializeField]
    private float _fireRate = 3;

    private float timer;
    private Transform target;

    private void Awake()
    {
        timer = Time.time;
        target = Player.PlayerUnit.TargetPoint;
    }

    private void Update()
    {
        //_sc.LookAtUnit(target);
    }


    private void ShootPlayer()
    {

    }
}

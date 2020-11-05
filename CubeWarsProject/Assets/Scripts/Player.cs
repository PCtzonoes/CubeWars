using UnityEngine;

public class Player : Unit
{

    private float _inputX;
    private float _inputZ;

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
        _rigidBody.velocity = new Vector3(_inputX, _rigidBody.velocity.y, _inputZ);
    }


    private void ReadInput()
    {
        _inputX = Input.GetAxis("Horizontal");
        _inputZ = Input.GetAxis("Vertical");
    }
}

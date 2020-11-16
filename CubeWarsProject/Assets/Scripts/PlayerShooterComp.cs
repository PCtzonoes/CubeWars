using UnityEngine;

public class PlayerShooterComp : ShooterComp
{
    private Vector3 _mouseInput;
    private int _layerMask;

    private void Awake()
    {
        _heightPoint = _headAxisPoint.position.y;
        _layerMask = LayerMask.GetMask("Floor");
    }

    private void Update()
    {
        _mouseInput = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(_mouseInput);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask))
        {
            Vector3 pos = hit.point;
            pos.y = _heightPoint;
            pos -= _headAxisPoint.position;

            if (pos.magnitude > 2.75f)
                _headAxisPoint.transform.rotation = Quaternion.LookRotation(pos, Vector3.up);


        }
    }

}

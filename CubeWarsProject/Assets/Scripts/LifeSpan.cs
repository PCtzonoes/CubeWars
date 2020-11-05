using UnityEngine;

public class LifeSpan : MonoBehaviour
{
    [SerializeField]
    private float _lifeTime = 5;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
}

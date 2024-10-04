using UnityEngine;

public class WindPlatform : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _windForce = 10f;
    [SerializeField] private float _changeDirectionInterval = 2f;
    private float _timeSinceLastChange = 0f;
    private Vector3 _windDirection;

    void Start()
    {
        ChangeWindDirection();
    }

    void Update()
    {
        _timeSinceLastChange += Time.deltaTime;
        if (_timeSinceLastChange >= _changeDirectionInterval)
        {
            ChangeWindDirection();
            _timeSinceLastChange = 0f;
        }
    }

    void ChangeWindDirection()
    {
        _windDirection = Random.Range(0, 2) == 0 ? Vector3.left : Vector3.right;
    }

    void OnTriggerStay(Collider other)
    {
        if (((1 << other.gameObject.layer) & _playerLayer) != 0)
        {
            if (other.TryGetComponent<CharacterController>(out var controller))
            {
                controller.Move(_windForce * Time.deltaTime * _windDirection);
            }
        }
    }
}

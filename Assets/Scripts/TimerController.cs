using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float Timer { get; private set; }
    [SerializeField] private bool _isTimeRunning;
    [SerializeField] private LayerMask _playerLayerMask;

    private void Start()
    {
        _isTimeRunning = false;
        Timer = 0;
    }

    void Update()
    {
        if (_isTimeRunning)
        {
            Timer += Time.deltaTime;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & _playerLayerMask) != 0)
        {
            _isTimeRunning = true;
        }
    }
}
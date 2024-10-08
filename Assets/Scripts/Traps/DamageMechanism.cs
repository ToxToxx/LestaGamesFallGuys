using System.Collections;
using UnityEngine;

public class DamageMechanism : MonoBehaviour
{
    [SerializeField] private Renderer _trapRenderer;
    [SerializeField] private Color _activatedColor;
    [SerializeField] private Color _damageColor = Color.red;
    [SerializeField] private Color _defaultColor = Color.white;
    [SerializeField] private float _damageDelay = 1f;
    [SerializeField] private float _cooldownTime = 5f;
    [SerializeField] private LayerMask _playerLayer;

    private DamageTrap _damageTrap;
    private bool _isTrapActive = false;
    private bool _isPlayerOnTrap = false;

    private WaitForSeconds _damageWait;
    private WaitForSeconds _cooldownWait;

    private void Start()
    {
        _damageTrap = GetComponent<DamageTrap>();
        _damageWait = new WaitForSeconds(_damageDelay);
        _cooldownWait = new WaitForSeconds(_cooldownTime);
    }

    private void ActivateTrap()
    {
        if (!_isTrapActive)
        {
            StartCoroutine(TrapSequence());
        }
    }

    private IEnumerator TrapSequence()
    {
        Debug.Log("Trap activated");
        _isTrapActive = true;

        _trapRenderer.material.color = _activatedColor;

        yield return _damageWait;

        _trapRenderer.material.color = _damageColor;

        if (_isPlayerOnTrap)
        {
            _damageTrap.DealDamage();
        }

        yield return new WaitForSeconds(0.1f);
        _trapRenderer.material.color = _defaultColor;

        yield return _cooldownWait;

        _isTrapActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsPlayer(other))
        {
            Debug.Log("Player Collided");
            _isPlayerOnTrap = true;
            ActivateTrap();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsPlayer(other))
        {
            Debug.Log("Player Exited");
            _isPlayerOnTrap = false;
        }
    }

    private bool IsPlayer(Collider other)
    {
        return ((1 << other.gameObject.layer) & _playerLayer) != 0;
    }
}

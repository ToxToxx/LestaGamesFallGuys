using System;
using UnityEngine;

public class PlayerBorderController : MonoBehaviour
{
    [SerializeField] private float _yBorder;
    [SerializeField] private Transform _playerTransform;

    public static event Action<int> OnPlayerFalling;

    private void Update()
    {
        if (_playerTransform.position.y < _yBorder)
        {
            PlayerFalling();
        }
    }
    public void PlayerFalling()
    {
        Debug.Log("Player is falling");
        OnPlayerFalling?.Invoke(3);
    }
}

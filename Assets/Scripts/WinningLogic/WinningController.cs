using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningController : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayerMask;
    [SerializeField] private Canvas _winningCanvas;

    private void ShowWinningScreen()
    {
        Time.timeScale = 0f;
        _winningCanvas.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _playerLayerMask) != 0)
        {
            Debug.Log("PlayerWin");
            ShowWinningScreen();
        }
    }
}

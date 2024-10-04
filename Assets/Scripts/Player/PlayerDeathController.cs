using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{
    [SerializeField] private Canvas _loosingCanvas;

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += ShowDeathScreen;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= ShowDeathScreen;
    }

    private void ShowDeathScreen()
    {
        Time.timeScale = 0f;
        _loosingCanvas.gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TimeController _timeController;

    private void Update()
    {
        _timerText.text = "Time: " + _timeController.Timer.ToString("F2");
    }
}
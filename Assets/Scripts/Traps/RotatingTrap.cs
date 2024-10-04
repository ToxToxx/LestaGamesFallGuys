using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTrap : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 0.1f;

    private void Update()
    {
        transform.Rotate(transform.rotation.x, _rotationSpeed, transform.rotation.z);
    }
}

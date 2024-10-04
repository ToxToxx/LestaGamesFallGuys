using UnityEngine;

public class ShakyTrap : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 0.1f;

    private void Update()
    {
        transform.Rotate(_rotationSpeed, transform.rotation.y, transform.rotation.z);
    }
}

using System.Collections;
using UnityEngine;

public class PlatformsHidingWall : MonoBehaviour
{
    [SerializeField] private GameObject[] _hidingPlatforms;
    [SerializeField] private float _timer = 2f; 
    [SerializeField] private float _zOffset = 5f; 
    [SerializeField] private float _moveDuration = 0.1f; 

    private Vector3[] _originalPositions;

    private void Start()
    {
        _originalPositions = new Vector3[_hidingPlatforms.Length];
        for (int i = 0; i < _hidingPlatforms.Length; i++)
        {
            _originalPositions[i] = _hidingPlatforms[i].transform.position; 
        }
        StartCoroutine(HidePlatformsRoutine());
    }

    private IEnumerator HidePlatformsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timer);

            MovePlatforms(_zOffset);

            yield return new WaitForSeconds(_moveDuration);

            MovePlatforms(0);
        }
    }

    private void MovePlatforms(float offset)
    {
        foreach (GameObject platform in _hidingPlatforms)
        {
            Vector3 newPosition = platform.transform.position;
            newPosition.z = _originalPositions[System.Array.IndexOf(_hidingPlatforms, platform)].z + offset;
            platform.transform.position = newPosition;
        }
    }
}

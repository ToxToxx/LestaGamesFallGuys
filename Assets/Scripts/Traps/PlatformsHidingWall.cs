using System.Collections;
using UnityEngine;

public class PlatformsHidingWall : MonoBehaviour
{
    [SerializeField] private GameObject[] _hidingPlatforms;
    [SerializeField] private float _timer = 2f; 
    [SerializeField] private float _zOffset = 5f; 
    [SerializeField] private float _moveDuration = 0.1f; 
    [SerializeField] private float _platformDelay = 0.5f; 

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

            for (int i = 0; i < _hidingPlatforms.Length; i++)
            {
                StartCoroutine(MovePlatform(_hidingPlatforms[i], _zOffset));
                yield return new WaitForSeconds(_platformDelay); 
            }

            yield return new WaitForSeconds(_moveDuration + _platformDelay * _hidingPlatforms.Length);

            for (int i = 0; i < _hidingPlatforms.Length; i++)
            {
                StartCoroutine(MovePlatform(_hidingPlatforms[i], 0));
                yield return new WaitForSeconds(_platformDelay); 
            }


            yield return new WaitForSeconds(_timer);
        }
    }

    private IEnumerator MovePlatform(GameObject platform, float zOffset)
    {
        Vector3 targetPosition = _originalPositions[System.Array.IndexOf(_hidingPlatforms, platform)];
        targetPosition.z += zOffset;

        Vector3 startPosition = platform.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < _moveDuration)
        {
            platform.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / _moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        platform.transform.position = targetPosition; 
    }
}

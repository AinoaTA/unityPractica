using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothTime = 0.2f;

    private float _zOffset = -10;
    private Vector3 _refVel = Vector3.zero;

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _target.position + Vector3.forward * _zOffset,
            ref _refVel, _smoothTime);
    }
}
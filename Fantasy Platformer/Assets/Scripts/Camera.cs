using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed = 0.05f;
    [SerializeField] private float _limitLeft;
    [SerializeField] private float _limitRight;
    [SerializeField] private float _limitBottom;
    [SerializeField] private float _limitUpper;

    private Vector3 _cameraTargetPosition;

    private void Update()
    {
        Move();
        Limit();
    }

    private void Move()
    {
        _cameraTargetPosition = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, _cameraTargetPosition, _speed);
    }

    private void Limit() 
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _limitLeft, _limitRight), (Mathf.Clamp(transform.position.y, _limitBottom, _limitUpper)), transform.position.z);
    }
}

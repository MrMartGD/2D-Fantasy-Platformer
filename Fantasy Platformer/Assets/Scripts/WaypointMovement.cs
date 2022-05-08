using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed = 2;

    private Transform[] _points;
    private Transform _target;
    private int _count = 0;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++) 
        {
            _points[i] = _path.GetChild(i);
        }
    }
      
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _target = _points[_count];

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
                
        if (transform.position == _target.position) 
        {
            _count++;
                       
            if (_count >= _points.Length) 
            {
                _count = 0;
            }
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Chest : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Coin _coinPrefab;

    private Transform[] _points;
    private Animator _animator;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++) 
        {
            _points[i] = _spawnPoints.GetChild(i);
        }

        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player)) 
        {
            _animator.SetTrigger(AnimatorEnvironmentController.States.Open);
            
            Spawn();

            GetComponent<Collider2D>().enabled = false;
        }
    }

    private void Spawn() 
    {
        for (int i = 0; i < _points.Length; i++) 
        {
            Instantiate(_coinPrefab, _points[i].position, Quaternion.identity);
        }
    }
}

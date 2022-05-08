using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _healthMax;
    
    private int _healthCurrent; 
    private Animator _animator;
    private Vector3 _currenPosition;
    private Vector3 _lastPosition;

    public void TakeDamage(int damage) 
    {
        _animator.SetTrigger(AnimatorEnemyController.States.Damage);
             
        _healthCurrent -= damage;

        if (_healthCurrent <= 0) 
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        
        _healthCurrent = _healthMax;
    }

    private void Update()
    {
         Flip();
    }

    private void Flip()
    {
        _lastPosition = _currenPosition;
        _currenPosition = transform.position;
        
        if (_lastPosition.x < _currenPosition.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (_lastPosition.x > _currenPosition.x)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}

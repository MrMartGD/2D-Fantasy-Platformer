using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _healthMax;
    
    private int _healthCurrent; 
    private Animator _animator;
   
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
}

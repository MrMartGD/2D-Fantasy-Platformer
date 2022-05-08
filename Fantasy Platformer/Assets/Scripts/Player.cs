using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private Wallet _wallet;
    private Animator _animator;

    private void Start()
    {
        _wallet = GetComponent<Wallet>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _wallet.AddCoin(coin.Value);
            
            coin.gameObject.SetActive(false);
        }
        
        if (collision.TryGetComponent(out Enemy enemy)) 
        {
            StartCoroutine(Die());
        }

        if (collision.TryGetComponent(out Water water)) 
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator Die() 
    {
        _animator.SetTrigger(AnimatorPlayerController.States.Die);

        yield return new WaitForSeconds(0.8f);

        gameObject.SetActive(false);
    }
}

using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coin = 0;

    public void AddCoin(int value) 
    {
        _coin += value;
        Debug.Log(_coin);
    }
}

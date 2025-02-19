using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class Rama : MonoBehaviour
{
     public void OnCollected()
    {
        GameManager.gameManager.CoinCollected(1);
        Destroy(gameObject);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Fruit>())
        {
            Destroy(collision.gameObject);
        }
    }
}

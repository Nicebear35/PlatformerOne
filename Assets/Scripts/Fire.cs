using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _destroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            _player.TakeDamage();
        }

        if (collision.GetComponent<Fruit>() || collision.GetComponent<Saw>())
        {
            Destroy(collision.gameObject);

            Destroy(Instantiate(_destroy, transform.position, Quaternion.identity), 0.3f);
        }
    }
}

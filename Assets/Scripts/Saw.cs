using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private Object _destroy;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _impulseVector = new Vector2();
    private float _minImpulse = -1f;
    private float _maxImpulse = 1f;
    private float _force = 4f;

    private void OnEnable() // срабатывает при включении или создании объекта
    {
        _impulseVector.x = Random.Range(_minImpulse, _maxImpulse);
        _impulseVector.y = Random.Range(_minImpulse, _maxImpulse);

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(_impulseVector * _force, ForceMode2D.Impulse);
    }
}

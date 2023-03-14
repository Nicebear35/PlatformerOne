using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Saw _saw;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private Vector2 _spawnPlace = new Vector2();
    private float _leftSpawnX = -7f;
    private float _rightSpawnX = 7f;
    private WaitForSeconds _sawSpawnCooldown = new WaitForSeconds(3f);
    
    private void Start()
    {
        _spawnPlace.y = transform.position.y;
        StartCoroutine(SpawnSaws());
    }

    private IEnumerator SpawnSaws()
    {
        while (_player.IsAlive)
        {
            _spawnPlace.x = Random.Range(_leftSpawnX, _rightSpawnX);
            Instantiate(_saw, _spawnPlace, Quaternion.identity);
            
            yield return _sawSpawnCooldown;
        }
    }
}

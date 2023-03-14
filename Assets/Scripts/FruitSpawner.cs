using System.Collections;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private Object[] _fruits;
    [SerializeField] private Player _player;

    private WaitForSeconds _spawnCooldown;
    private float _leftSpawnPosition = -7f;
    private float _rightSpawnposition = 7f;
    private Vector2 _spawnPosition = new Vector2();

    private void Start()
    {
        _spawnCooldown = new WaitForSeconds(1f);
        _spawnPosition.y = transform.position.y;
        StartCoroutine(SpawnFruits());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _player.Heal();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _player.TakeDamage();
        }
    }

    private IEnumerator SpawnFruits()
    {
        while (_player.IsAlive)
        {
            _spawnPosition.x = Random.Range(_leftSpawnPosition, _rightSpawnposition);
            Instantiate(_fruits[Random.Range(0, _fruits.Length)], _spawnPosition, Quaternion.identity);
            yield return _spawnCooldown;
        }
    }
}

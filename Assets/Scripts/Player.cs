using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Object _destroy;
    [SerializeField] private AudioSource _pickUpFruitSound;
    [SerializeField] private AudioSource _takeDamageSound;

    private bool _isAlive = true;
    private int _currentHealth;
    private int _maxHealth = 5;
    private float _damageVelocity = 10;
    private WaitForSeconds _damageTiming = new WaitForSeconds(0.3f);

    public bool IsAlive => _isAlive;
    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Saw>())
        {
            TakeDamage();            
            Destroy(collision.gameObject);
            Destroy(Instantiate(_destroy, transform.position, Quaternion.identity), 0.3f);
        }

        if (collision.GetComponent<Fruit>())
        {
            Heal();            
            Destroy(collision.gameObject);
            Destroy(Instantiate(_destroy, transform.position, Quaternion.identity), 0.3f);
        }
    }

    public void Heal()
    {
        _pickUpFruitSound.Play();
        _currentHealth++;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        Debug.Log($"HEAL!! HP = {_currentHealth}");
    }

    public void TakeDamage()
    {
        _takeDamageSound.Play();
        _rigidbody2D.velocity = Vector2.up * _damageVelocity;
        StartCoroutine(SetColor(Color.red, Color.white));
        _currentHealth--;


        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _isAlive = false;
        }

        Debug.Log($"DAMAGE!! HP = {_currentHealth}");
    }

    private IEnumerator SetColor(Color newColor, Color defaultColor)
    {
        _spriteRenderer.color = newColor;
        yield return _damageTiming;
        _spriteRenderer.color = defaultColor;
    }
}

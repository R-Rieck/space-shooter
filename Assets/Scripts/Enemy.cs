using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;
    public GameObject DestroyAnim;

    private bool _entered = true;
    private float _life = 100f;
    private int _damage = 1;

    private Player _player;
    private Animator _destroyAnimation;

    
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        transform.position = new Vector3(Random.Range(-9f, 9f), 7);

        _player = GameObject.Find("Player").GetComponent<Player>();
        _destroyAnimation = gameObject.GetComponent<Animator>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (_player == null || _destroyAnimation == null)
            Debug.Log($"the given object {_player} or {_destroyAnimation} is null");
    }

    void Update()
    {
        transform.Translate(Vector3.down * _movementSpeed * Time.deltaTime);

        if (transform.position.y <= -6f)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (_life <= 0f)
        {
            Instantiate(DestroyAnim, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collider.name == "Player")
        {
            Instantiate(DestroyAnim, transform.position, Quaternion.identity);
            _spriteRenderer.sortingLayerName = "Background";
            Destroy(this.gameObject);
            _player.AddToScore(10);
            _player.ReceiveDamage(_damage);
        }

        if (collider.tag == "Laser")
        {
            Destroy(collider.gameObject);
            _player.AddToScore(5);
            _life -= collider.gameObject.GetComponent<Bullet>().Damage;
        }


    }
}

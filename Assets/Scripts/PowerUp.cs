using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 2;

    [SerializeField]
    private int _powerupId;

    void Start() => transform.position = new Vector2(Random.Range(-8f, 8f), Random.Range(4f, 5f));

    void Update()
    {
        transform.Translate(Vector2.down * _movementSpeed * Time.deltaTime);

        if (transform.position.y <= -5.5)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var player = collision.GetComponent<Player>();
            Destroy(this.gameObject);

            if (player != null)
            {
                switch (_powerupId)
                {
                    case 0:
                        player.EnableTripleShot();
                        break;
                    case 1:
                        player.EnableSpeedBoost();
                        break;
                    case 2:
                        player.EnableShield();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

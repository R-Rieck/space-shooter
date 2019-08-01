using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _shootingSpeed = 10;

    [SerializeField]
    public float Damage = 20;

    void Update() => Shoot();

    void Shoot()
    {
        transform.Translate(Vector3.up * _shootingSpeed * Time.deltaTime);

        if (transform.position.y >= 5.5)
        {
            Destroy(gameObject);

            try
            {
                var bulletContainer = transform.parent.gameObject;

                if (bulletContainer != null)
                {
                    Destroy(transform.parent.gameObject);
                }
                else
                {
                    Debug.Log("fuck this nullreferenceError");
                }
            }
            catch (System.Exception) { }
        }
    }
}

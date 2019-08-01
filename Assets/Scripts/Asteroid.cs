using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float _movementSpeed = 1;
    public GameObject explosionAnim;

    private SpriteRenderer _spriteRenderer;

    void Update() => transform.Rotate(new Vector3(0, 0, 5) * Time.deltaTime * _movementSpeed, Space.Self);

    private void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (_spriteRenderer == null)
            Debug.LogError("Sprite Renderer is NULL");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Laser")
        {
            Destroy(col.gameObject);
            _spriteRenderer.sortingLayerName = "Background";
            Instantiate(explosionAnim,gameObject.transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

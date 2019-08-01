using System.Collections;
using UnityEngine;


public class Player : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;
    private float _canFire = 0f;
    private Vector3 _direction;
    private int DamageIndicatorTemp;

    [SerializeField]
    private float _moveSpeed = 10f;
    [SerializeField]
    private int _life = 3;
    [SerializeField]
    private float _fireRate;
    [SerializeField]
    private bool _tripleShotIsEnabled = false;
    [SerializeField]
    private bool _speedBoostIsEnabled = false;
    [SerializeField]
    private bool _shieldIsEnabled = false;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private GameObject _tripleShot;
    [SerializeField]
    private GameObject _shield;
    [SerializeField]
    private GameObject[] _EngineDamageIndicators;
    [SerializeField]
    private int _score = 0;

    private SpawnBehaviour _spawnBehaviour;
    private UiManager _uiManager;

    public AudioSource _laserShot;
    public AudioSource _powerUpSound;
    public AudioSource _alterSound;

    void Start()
    {
        _spawnBehaviour = GameObject.Find("SpawnManager").GetComponent<SpawnBehaviour>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();

        DamageIndicatorTemp = Random.Range(0, 3);
    }

    void Update()
    {
        PlayerMovement();
        InitBullet();

        handleCoroutines();
    }

    private void InitBullet()
    {
        if ((Input.GetKey(KeyCode.JoystickButton2) || Input.GetKey(KeyCode.Space)) && Time.time > _canFire)
        {
            if (_tripleShotIsEnabled)
            {
                _canFire = Time.time + _fireRate;
                SpawnTripleBullet();
            }
            else
            {
                _canFire = Time.time + _fireRate;
                SpawnBullet();
            }
        }
    }

    void PlayerMovement()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _direction = new Vector3(_horizontalInput, _verticalInput, 0);

        transform.Translate(_direction * _moveSpeed * Time.deltaTime);

        if (transform.position.y >= 5.25f)
            transform.position = new Vector3(transform.position.x, 5.25f);
        else if (transform.position.y <= -3.57f)
            transform.position = new Vector3(transform.position.x, -3.57f);

        if (transform.position.x >= 9.5f)
            transform.position = new Vector3(9.5f, transform.position.y);
        else if (transform.position.x <= -9.5f)
            transform.position = new Vector3(-9.5f, transform.position.y);
    }

    public void ReceiveDamage(int damageAmount)
    {
        CheckDamageIndicator();

        if (!_shieldIsEnabled)
        {
            _alterSound.Play();
            _life -= damageAmount;
            _uiManager.UpdateLives(_life);
        }
        if (_life <= 0)
        {
            Destroy(this.gameObject);
            _spawnBehaviour.IsPlayerAlive(false);
        }
    }

    private void CheckDamageIndicator()
    {
        var newIndicatorState = 0;
        switch (_life)
        {
            case 2:
                if (DamageIndicatorTemp == 0)
                    newIndicatorState = 1;
                else
                    newIndicatorState = 0;
                _EngineDamageIndicators[newIndicatorState].SetActive(true);
                break;
            case 3:
                if (DamageIndicatorTemp == 0)
                    newIndicatorState = 1;
                else
                    newIndicatorState = 0;
                _EngineDamageIndicators[newIndicatorState].SetActive(true);
                break;
            default:
                break;
        }
        DamageIndicatorTemp = newIndicatorState;
    }

    public void AddToScore(int val)
    {
        _score += val;
        _uiManager.UpdateScore(_score);
    }


    public void EnableTripleShot()
    {
        _powerUpSound.Play();
        _tripleShotIsEnabled = true;
    }
    public void EnableSpeedBoost()
    {
        _powerUpSound.Play();
        _speedBoostIsEnabled = true;
    }
    public void EnableShield()
    {
        _powerUpSound.Play();
        _shieldIsEnabled = true;
    }
    
    void SpawnTripleBullet()
    {
        _laserShot.Play(0);
        Instantiate(_tripleShot, new Vector3(transform.position.x - 0.8f, transform.position.y + 1.2f), Quaternion.identity);
    }
    void SpawnBullet()
    {
        Instantiate(_bullet, new Vector3(transform.position.x, transform.position.y + 1), Quaternion.identity);
        _laserShot.Play(0);
    }


    void handleCoroutines()
    {
        if (_tripleShotIsEnabled)
            StartCoroutine(ToggleTripleShot());

        if (_speedBoostIsEnabled)
            StartCoroutine(ToggleSpeedBoost());

        if (_shieldIsEnabled)
            StartCoroutine(ToggleShield());
    }

    IEnumerator ToggleShield()
    {
        _shield.SetActive(true);
        yield return new WaitForSeconds(3);
        _shield.SetActive(false);
        DisableShield();
    }

    IEnumerator ToggleSpeedBoost()
    {
        _fireRate /= 2;
        DisableSpeedBoost();
        yield return new WaitForSeconds(10);
        _fireRate *= 2;
    }

    IEnumerator ToggleTripleShot()
    {
        yield return new WaitForSeconds(10);
        DisableTripleShot();
    }

    public void DisableSpeedBoost() => _speedBoostIsEnabled = false;
    public void DisableTripleShot() => _tripleShotIsEnabled = false;
    public void DisableShield() => _shieldIsEnabled = false;
}

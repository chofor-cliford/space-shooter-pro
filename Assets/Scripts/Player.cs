using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;
    
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.15f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();

        if (_spawnManager == null) {
            Debug.LogError("The Spawn Manager is NULL.");
        }

    }

    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire) {
            ShootLaser();
        }
    }

    void CalculateMovement() 
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        // Move the player
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        // Clamp Y-axis to prevent moving too high or too low
        float clampedY = Mathf.Clamp(transform.position.y, -4.2f, 0);
        transform.position = new Vector3(transform.position.x, clampedY, 0);

        // Wrap X-axis for player movement across screen bounds
        if (transform.position.x > 11f) {
            transform.position = new Vector3(-11f, transform.position.y, 0);
        } else if (transform.position.x < -11f) {
            transform.position = new Vector3(11f, transform.position.y, 0);
        }
    }

    void ShootLaser() {
        // Shoot laser when the space key is pressed
        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    }

    public void Damage() {
        _lives--;
        // check if dead
        // if dead destroy us
        if (_lives < 1) {
            // Communicate with SpawnManager
            _spawnManager.OnPlayerDeath();
            //Let them know to stop spawning

            Destroy(this.gameObject);
        }
    }
}

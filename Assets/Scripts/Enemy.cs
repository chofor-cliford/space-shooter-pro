using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 4.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move down at 4 meters per second
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        // if bottom of screen
        // respawn at top with a new random x position
        if (transform.position.y < -5.5f) {
            float randomX = Random.Range(-9.5f, 9.5f);  
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

    private void OnTriggerEnter(Collider other) {
        // if other is player
        if (other.tag == "Player") {

            // damage the player
            Player player = other.transform.GetComponent<Player>();
            
            if (player != null) {
                player.Damage();
            }

            Destroy(this.gameObject);

        } else if (other.tag == "Laser") {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        // Damage the player
        // Destroy the Us

        // if other is laser
        // laser
        // Destroy us
    }
}

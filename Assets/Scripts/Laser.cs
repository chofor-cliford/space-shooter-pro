using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 8.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      // translate laser up
      // if the position on the y is greater than 8
      // destroy the object
      transform.Translate(Vector3.up * _speed * Time.deltaTime);  

        // if the position on the y is greater than 8
        // destroy the object
        if (transform.position.y > 8f && transform.parent != null)
        {
            // destroy the object we are attached to
            Destroy(this.gameObject);
        }
    }
}

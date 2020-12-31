using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Platform : MonoBehaviour
{
    [SerializeField] float speed = 1;
    float limit = -11;
   
    // Update is called once per frame
    void Update()
    {
        // Set the playform to move on the x axis by it's speed (negative value sends it to the left).
        transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;

        // Destroy the platform when it reaches a certain value on the x.
        if (transform.position.x < limit)
        {
            Destroy(this.gameObject);
        }
    }

    
}

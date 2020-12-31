using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    [SerializeField] GameObject[] platformPrefab;
    [SerializeField] Transform referencePoint;
    [SerializeField] GameObject lastCreatedPlatform;
    float lastPlatformWidth;

    // Update is called once per frame
    void Update()
    {
        // If the last created platforms position is less than the Reference point's...
        if (lastCreatedPlatform.transform.position.x < referencePoint.position.x )
        {
            float randomPlatformGap = Random.Range(2, 5);

            // Create and set a new position to spawn the next Platform.
            Vector3 targetCreationPoint = new Vector3(referencePoint.position.x + lastPlatformWidth + randomPlatformGap, -4.4f, 0);
            
            // Create a variable to store a reference to one of the Platforms in the array, selected randomly.
            int randomPlatform = Random.Range(0, platformPrefab.Length);

            // Create a platform at the targeted location and set the created platform as a reference to the last created Platform.
            lastCreatedPlatform = Instantiate(platformPrefab[randomPlatform], targetCreationPoint, Quaternion.identity);
           
            // Create and set a reference to the last created Platform's collider.
            BoxCollider2D collider = lastCreatedPlatform.GetComponent<BoxCollider2D>();
            
            // Assign the variable to the width of the collider.
            lastPlatformWidth = collider.bounds.size.x; 
        }
    }
}

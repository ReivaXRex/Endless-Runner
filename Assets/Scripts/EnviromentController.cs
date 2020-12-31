using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentController : MonoBehaviour
{
    [SerializeField] GameObject[] enviromentPrefab;
    [SerializeField] Transform referencePoint;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateEnviromentElement());
    }

    IEnumerator CreateEnviromentElement()
    {
        Vector3 offset = new Vector3(10, 0, 0);
        int randomTree = Random.Range(0, 2);
        Instantiate(enviromentPrefab[randomTree], referencePoint.position + offset, Quaternion.identity);
        yield return new WaitForSeconds(3);
        StartCoroutine(CreateEnviromentElement());
        // yield return null; 
    }
}

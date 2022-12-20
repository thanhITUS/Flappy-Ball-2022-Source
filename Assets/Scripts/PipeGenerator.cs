using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pipePrefabs;
    private float count;
    public float timeDelay;
    public bool enablePipe;
    private void Awake()
    {
        count = timeDelay;
        enablePipe = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enablePipe)
        {
            count -= Time.deltaTime;
            if (count <= 0)
            {
                Instantiate(pipePrefabs, new Vector3(10, Random.Range(-1.2f, 2.1f), 0), Quaternion.identity);
                count = timeDelay;
            }
        } 
    }
}

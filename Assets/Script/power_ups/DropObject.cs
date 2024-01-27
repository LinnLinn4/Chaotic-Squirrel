using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var droppers = GameObject.FindGameObjectsWithTag(StringHolder.Dropper);
        int rand = Random.Range(0, droppers.Length);
        droppers[rand].GetComponent<Spawner>().spawnSingleObject();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

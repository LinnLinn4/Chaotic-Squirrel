using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{


    [SerializeField]
    private List<GameObject> prefabs;
    // Start is called before the first frame update
    [SerializeField]
    bool isSpawn = true;


    void Start()
    {
        if (isSpawn)
        {
            float randomTime = Random.RandomRange(1.5f, 5f);
            StartCoroutine(spawn(randomTime));
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnSingleObject()
    {
        int rand = Random.Range(0, prefabs.Count);
        Instantiate(prefabs[rand], transform);
    }

    IEnumerator spawn(float duration)
    {

        yield return wait(duration);
        int rand = Random.Range(0, prefabs.Count);
        Instantiate(prefabs[rand], transform);
        if (isSpawn)
        {
            float randomTime = Random.RandomRange(1f, 5f);
            StartCoroutine(spawn(randomTime));
        }
    }
    IEnumerator wait(float waitTime)
    {
        float counter = 0;

        while (counter < waitTime)
        {
            counter += Time.deltaTime;

            yield return null;
        }
    }
    public void toggleSpawn(bool _isSpawn)
    {
        isSpawn = _isSpawn;
        if (isSpawn)
        {
            float randomTime = Random.RandomRange(0.5f, 10f);
            StartCoroutine(spawn(randomTime));
        }

    }
}

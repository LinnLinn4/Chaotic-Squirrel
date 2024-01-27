using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{

    bool isFinished = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * GeneralObjectMovement.speed);
        if (isFinished)
        {
            return;
        }
        if (transform.position.y < -7)
        {
            isFinished = true;
            StartCoroutine(SetOriginal());
        }

    }
    IEnumerator SetOriginal()
    {

        yield return wait(5f);
        Destroy(gameObject);

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
}

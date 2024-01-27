using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralObjectMovement : MonoBehaviour
{


    [SerializeField]
    public static float speed = 4;
    bool isFinished = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - Time.deltaTime * speed, transform.position.y);
        if (isFinished)
        {
            return;
        }
        if (transform.position.x < -10)
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

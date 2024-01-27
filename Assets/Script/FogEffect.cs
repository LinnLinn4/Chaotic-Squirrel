using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FogEffect : MonoBehaviour
{

    [SerializeField]
    private float reRotateTimer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetFogEffect()
    {
        transform.GetComponent<SpriteRenderer>().DOColor(Color.gray, 1);
        StartCoroutine(SetOriginal());
    }


    IEnumerator SetOriginal()
    {

        yield return wait(reRotateTimer);
        transform.GetComponent<SpriteRenderer>().DOColor(new Color(0, 0, 0, 0), 1);

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

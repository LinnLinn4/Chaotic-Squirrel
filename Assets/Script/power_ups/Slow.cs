using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    bool isActive = true;
    private AudioSource ad;

    // Start is called before the first frame update
    void Start()
    {
        ad = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActive)
        {
            return;
        }
        isActive = false;
        transform.GetComponent<SpriteRenderer>().DOColor(new Color(0, 0, 0, 0), 1);
        ad.Play();
        GeneralObjectMovement.speed /= 1.3f;
        Player.instance.gravityScale /= 1.3f;
        StartCoroutine(SetOriginal());

    }
    IEnumerator SetOriginal()
    {

        yield return wait(5f);
        GeneralObjectMovement.speed *= 1.35f;
        Player.instance.gravityScale *= 1.35f;
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
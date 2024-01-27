using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Reverse : MonoBehaviour
{
    private Camera mainCamera;

    private bool isActive = true;

    [SerializeField]
    private float reRotateTimer = 5f;
    private AudioSource ad;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
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
        Rotate(180);
        StartCoroutine(SetOriginalRotation());
        ad.Play();
        //transform.GetComponent<SpriteRenderer>().enabled = false;
        transform.GetComponent<SpriteRenderer>().DOColor(new Color(0, 0, 0, 0), 1);
    }

    void Rotate(float value)
    {
        mainCamera.transform.DORotate(new Vector3(0, 0, value), 0.5f);


    }
    IEnumerator SetOriginalRotation()
    {

        yield return wait(reRotateTimer);
        Rotate(0);
        yield return wait(1f);
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

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseKey : MonoBehaviour
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
        Player.instance.changeMovementKey();
        ad.Play();
        transform.GetComponent<SpriteRenderer>().DOColor(new Color(0, 0, 0, 0), 1);
    }
}

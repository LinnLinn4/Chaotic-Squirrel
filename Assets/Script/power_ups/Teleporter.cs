using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
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
        int rand = Random.Range(0, 3);
        Vector3 oldPos = Player.instance.transform.position;
        ad.Play();
        Player.instance.currentLane = rand;
        if (rand == 0)
        {

            Player.instance.transform.position = new Vector3(Random.Range(-8, 8), 2.25f, oldPos.z);
        }
        else if (rand == 1)
        {
            Player.instance.transform.position = new Vector3(Random.Range(-8, 8), -1.2f, oldPos.z);

        }
        else
        {
            Player.instance.transform.position = new Vector3(Random.Range(-8, 8), -4.25f, oldPos.z);

        }

    }
}

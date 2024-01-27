using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InstantKill : MonoBehaviour
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
        if (!Player.instance.GetIsShieldOn())
        {
            Player.instance.health--;
            if (Player.instance.health >= 0)
            {
                for (int i = Player.instance.health; i <= 2; i++)
                {
                    Player.instance.GetHealthImages()[i].gameObject.SetActive(false);
                }
            }

        }
        else
        {
            Player.instance.SetIsShieldOn(false);
            Player.instance.GetShield().SetActive(false);
        }
        ad.Play();
        isActive = false;
        transform.GetComponent<SpriteRenderer>().DOColor(new Color(0, 0, 0, 0), 1);
    }
}

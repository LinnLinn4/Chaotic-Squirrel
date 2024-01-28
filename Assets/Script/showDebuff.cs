using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showDebuff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.reverseKeys)
        {
            transform.GetComponent<SpriteRenderer>().DOColor(new Color(255, 255, 255, 255), 1);
            //transform.GetComponent<Image>().DOColor(new Color(255, 255, 255, 255), 1);
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().DOColor(new Color(0, 0, 0, 0), 1);
            //transform.GetComponent<Image>().DOColor(new Color(0, 0, 0, 0), 1);
        }
    }
}

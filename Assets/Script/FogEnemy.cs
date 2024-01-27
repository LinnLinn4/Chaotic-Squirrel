using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FogEnemy : MonoBehaviour
{
    [SerializeField] private List<GameObject> fogs = new List<GameObject>();
    bool isActive = true;
    private AudioSource ad;

    // Start is called before the first frame update


    // Start is called before the first frame update
    void Start()
    {
        fogs = GameObject.FindGameObjectsWithTag(StringHolder.Fog).ToList();
        ad = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int rand = Random.Range(0, fogs.Count);
        transform.GetComponent<SpriteRenderer>().DOColor(new Color(0, 0, 0, 0), 1);
        ad.Play();
        fogs[rand].GetComponent<FogEffect>().SetFogEffect();

    }
}

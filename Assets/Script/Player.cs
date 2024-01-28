using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance { get; private set; }
    [SerializeField]
    private List<Transform> objToPlaceTransforms;
    private AudioSource ad;

    [SerializeField]
    private GameObject boostUI;
    private Animator anim;
    [SerializeField]
    private List<GameObject> walls;
    [SerializeField]
    public float gravityScale = 2;

    [SerializeField]
    public int health = 3;

    private bool isShieldOn = false;



    [SerializeField]
    public TMP_Text scoreText;

    [SerializeField]
    public TMP_Text gameoverScoreText;

    [SerializeField]
    private GameObject shield;

    private bool isMoving = false;
    public int currentLane = 2;
    private Rigidbody2D rb;


    private float originXPos = 0;

    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;

    //Effects on or not
    public bool reverseKeys = false;

    float boost = 20;


    public int score = 0;
    public bool isStunned = false;
    public bool isGameOverUIActive = false;
    [SerializeField]private GameObject gameOverUI;
    

    bool isStart = true;

    [SerializeField]
    private List<GameObject> healthImages;
    // Start is called before the first frame update

float boostWidth = 0;
float boostXPos = 0;

    private void Awake()
    {
        instance = this;
        originXPos = -7f;
    }
    void Start()
    {
        boostWidth =      boostUI.transform.localScale.x;
        boostXPos = boostUI.transform.position.x;
        ad = GetComponent<AudioSource>();
        // transform.position = objToPlaceTransforms[1].position;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(startSet());
        for (int i = 0; i < healthImages.Count; i++)
        {
            healthImages[i].SetActive(true);
        }
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
          GeneralObjectMovement.speed += Time.deltaTime * 0.4f;
        Player.instance.gravityScale += Time.deltaTime *0.4f;
        var oldScale = boostUI.transform.localScale;
        var oldBoostPos = boostUI.transform.position;

        boostUI.transform.localScale = new Vector3(boostWidth * (boost/20),oldScale.y,oldScale.z);
        float lostBoostWidth = boostWidth - boostWidth * ( boost/20) *0.5f;
        boostUI.transform.position = new Vector3( boostXPos -lostBoostWidth- boostXPos*0.25f + 0.2f,oldBoostPos.y,oldBoostPos.z);

        if (isStart)
        {
            float xPos = transform.position.x + Time.deltaTime * 5;
            transform.position = new Vector2(Mathf.Clamp(xPos, originXPos, 9999f), transform.position.y);
        }

        if(health <= 0){
            if(!isGameOverUIActive){
                isGameOverUIActive = true;
            gameOverUI.SetActive(true);
            gameoverScoreText.SetText("Score: "+((int)score).ToString());
            
            anim.SetBool("Death",true);
            }
            GeneralObjectMovement.speed = 4;
            Player.instance.gravityScale = 2;
        }

        scoreText.SetText(((int)score).ToString());
        //scoreText.GetComponent<Text>().text = ((int)score).ToString();
        if(boost<20){
            boost += Time.deltaTime * 5;
        }
        if (isStunned)
        {
            return;
        }
        if (Input.GetKeyDown(upKey) && !isMoving && currentLane > 0)
        {
            goUp();
        }
        if (Input.GetKeyDown(downKey) && !isMoving && currentLane < 2)
        {
            goDown();
        }

        if (Input.GetKey(KeyCode.Space) && boost >= 0)
        {
            boost -= Time.deltaTime * 20;
            transform.position = new Vector2(transform.position.x + Time.deltaTime * 5, transform.position.y);
        }
        else if (transform.position.x > originXPos)
        {
            float xPos = transform.position.x - Time.deltaTime * 5;
            transform.position = new Vector2(Mathf.Clamp(xPos, originXPos, 9999f), transform.position.y);
        }

    }
    public void goDown()
    {

        isMoving = true;
        currentLane++;
        SetWallRigidBody(true);
        rb.gravityScale = gravityScale;
        ad.Play();
    }
    public void goUp()
    {

        isMoving = true;
        currentLane--;
        StartCoroutine(SetWallRigidBodyWithWaitTime());
        rb.gravityScale = -gravityScale;
        ad.Play();
    }

    public void changeMovementKey()
    {
        reverseKeys = true;
        upKey = KeyCode.A;
        downKey = KeyCode.D;
        StartCoroutine(SetKeyBackToOriginal());

    }


    public void SetisMoving(bool _isMoving)
    {
        isMoving = _isMoving;
    }

    public void SetWallRigidBody(bool check)
    {
        if (!check)
        {
            isMoving = false;
        }
        for (int i = 0; i < walls.Count; i++)
        {
            walls[i].GetComponent<BoxCollider2D>().isTrigger = check;
        }
    }


    IEnumerator SetWallRigidBodyWithWaitTime()
    {

        yield return wait(0.05f);
        SetWallRigidBody(true);

    }
    IEnumerator SetKeyBackToOriginal()
    {

        yield return wait(5f);
        upKey = KeyCode.W;
        downKey = KeyCode.S;
        reverseKeys = false;

    }
    IEnumerator startSet()
    {

        yield return wait(2f);
        isStart = false;

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

    public bool GetIsShieldOn()
    {
        return isShieldOn;
    }

    public void SetIsShieldOn(bool _isShieldOn)
    {
        isShieldOn = _isShieldOn;
    }

    public GameObject GetShield()
    {
        return shield;
    }

    public List<GameObject> GetHealthImages()
    {
        return healthImages;
    }

    public void SetStunnedAnimator(bool _isStunnedAnimator)
    {
        anim.SetBool("Stun", _isStunnedAnimator);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void RestartButtonButton()
    {
        SceneManager.LoadScene("GamePlayScene");
    }
}

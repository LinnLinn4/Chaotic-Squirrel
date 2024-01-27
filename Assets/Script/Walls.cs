using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player.instance.GetComponent<Rigidbody2D>().gravityScale = Player.instance.gravityScale;
        Player.instance.SetisMoving(false);
        if (Player.instance.GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            Player.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(Player.instance.GetComponent<Rigidbody2D>().velocity.x, 0);
        }
        Player.instance.SetWallRigidBody(false);
    }

}

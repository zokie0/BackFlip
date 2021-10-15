using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject gameController;
    public GameObject menu;
    public Text menuT;
    public Text jumpT;
    public AudioSource jump1;
    public AudioSource jump2;
    public float maxJump = 5;
    public float jumpNum;
    public float speed = 5;
    public float jump = 10;
    public bool facingF = false;
    public bool recharging = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.simulated = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) & Time.timeScale != 0)          //TAP TO JUMP
        {
            rb.simulated = true;
            if (jumpNum > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
                if (!facingF) { jump1.Play(); } else { jump2.Play(); } // play audio q based on jump direction
                facingF = !facingF;
                jumpNum -= 1;
            }
        }


        if (facingF) // move left / right
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(speed * -1, rb.velocity.y);
        }

        if (jumpNum < maxJump & recharging == false) { StartCoroutine(jumpCharge()); } //regen jumps


        //text
        jumpT.text = "" + jumpNum;
    }

    private IEnumerator jumpCharge()
    {
        recharging = true;
        yield return new WaitForSeconds(1.0f);
        if (jumpNum < maxJump) { jumpNum += 1; }
        recharging = false;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //if (coll.gameObject.tag == "Wall")
        {
            //facingF = !facingF;
        }

        if (coll.gameObject.tag == "Up")
        {
            if (jumpNum < maxJump) { jumpNum += 1; }
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "Hurt")
        {
            menu.SetActive(true);
            menu.transform.position = new Vector3(0, this.transform.position.y + 1.8f, 0);
            menuT.text = "Score: \n \n" + Mathf.Round(gameController.GetComponent<Control>().height * 100);
            Time.timeScale = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// todo: if mouse on the back of player, rotate player, always shoot in the forward direction
public class PlayerController : MonoBehaviour
{

    //movement
    public float speed;
    public float jumpUpSpeed;
    public float gravityModifier = 1.5f;

    public Transform leftFoot;
    public Transform rightFoot;
    public Transform throwPoint;
    public float damageCD = 2f;

    bool grounded = true;
    bool faceRight = true;
    Rigidbody2D rb2d;
    SpriteRenderer sr;
    Collider2D playerCol;

    private Animator anim;

    public GameObject bomb;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        playerCol = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        // groundLayer = LayerMask.NameToLayer("Ground");
        // platformLayer = LayerMask.NameToLayer("Platform");
    }



    float moveVel;//temp use
    void Update()
    {
        // Debug.DrawRay(leftFoot.position, Vector2.down, Color.white);


        //ground check and platform check, need refactoring 
        RaycastHit2D g_left = Physics2D.Raycast(leftFoot.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
        RaycastHit2D g_right = Physics2D.Raycast(rightFoot.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
      //  RaycastHit2D p_left = Physics2D.Raycast(leftFoot.position, Vector2.down, 0.1f, LayerMask.GetMask("Platform"));
      //  RaycastHit2D p_right = Physics2D.Raycast(rightFoot.position, Vector2.down, 0.1f, LayerMask.GetMask("Platform"));
        if (g_left.collider || g_right.collider)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
            /*
            RaycastHit2D left = Physics2D.Raycast(leftBoundry.position, Vector2.down, 1, LayerMask.GetMask("Platform"));
            RaycastHit2D right = Physics2D.Raycast(rightBoundry.position, Vector2.down, 1, LayerMask.GetMask("Platform"));
            if(left)
            {
                Physics2D.IgnoreCollision(playerCol, left.collider);
                StartCoroutine(ResetIgnoreCollision(playerCol, left.collider));
            }
            if(right)
            {
                Physics2D.IgnoreCollision(playerCol, right.collider);
                StartCoroutine(ResetIgnoreCollision(playerCol, right.collider));
            }*/
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            if (grounded && canTakeDamage)
            {
                if (rb2d)
                {

                    rb2d.velocity = new Vector2(rb2d.velocity.x * 0.2f, jumpUpSpeed);
                    anim.SetTrigger("IsJump");
                    // inAir = true;
                }
            }
        }

        //modify jump gravity when falling 
        if (!grounded && rb2d.velocity.y < 0)
        {
            rb2d.AddForce(new Vector2(0, -9.81f * gravityModifier));

        }


        moveVel = 0;
        //left right move
        if (grounded)
        {
            if (Input.GetMouseButtonDown(0))
            {
               anim.SetTrigger("IsThrow");
               GameObject b= Instantiate(bomb, throwPoint.position, Quaternion.identity);
               b.GetComponent<BombController>().SetThrowDirection(faceRight);
            }




            // inAir = false;
            if (Input.GetKey(KeyCode.A) && canTakeDamage)
            {
                moveVel = -speed;
                faceRight = false;
            }
            if (Input.GetKey(KeyCode.D) && canTakeDamage)
            {
                moveVel = speed;
                faceRight = true;
            }
            if (rb2d)
            {
                rb2d.velocity = new Vector2(moveVel, rb2d.velocity.y);
            }
        }
        if (sr)
        {
            UpdateFaceDirection(faceRight);
        }
    }


    IEnumerator ResetIgnoreCollision(Collider2D left, Collider2D right)
    {
        yield return new WaitForSeconds(0.2f);
        Physics2D.IgnoreCollision(left, right, false);
    }


    void UpdateFaceDirection(bool faceright)
    {
        if (!faceright)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }


    bool canTakeDamage = true;
    public void OnDamaged(Vector2 ori)
    {
     /*   if (canTakeDamage)
        {
            HPManager hPManager = Global.GetHpManager();
            hPManager.ReduceValue();
            canTakeDamage = false;
            StartCoroutine(nameof(DamageCd));
            Vector2 diff = ori - (Vector2)transform.position;
            // rb2d.AddForce(diff.x > 0 ? new Vector2(-20, 2) : new Vector2(20, 2));
            if (diff.x > 0)
            {
                if (grounded)
                {
                    rb2d.AddForce(new Vector2(-100, 200));
                }
                else
                {
                    rb2d.AddForce(new Vector2(-50, 0));
                }
            }
            else
            {
                if (grounded)
                {
                    rb2d.AddForce(new Vector2(100, 200));
                }
                else
                {
                    rb2d.AddForce(new Vector2(50, 0));
                }
            }
        }
        */
    }

    IEnumerator DamageCd()
    {
        yield return new WaitForSeconds(damageCD);
        canTakeDamage = true;
    }

}
    
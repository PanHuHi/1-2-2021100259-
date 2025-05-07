using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float distance;
    public float atkDistance;
    public LayerMask isLayer;
    public float speed;

    public GameObject bullet;
    public Transform pos;
    public float cooltime;
    private float currenttime;
    public bool leftScan;
    public Animator animator;
    public float AttackCoolTime;

    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AttackCoolTime = AttackCoolTime - Time.deltaTime;
        RaycastHit2D right = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if (right.collider != null)
        {
            sprite.flipX = true;
            if (currenttime <= 0)
            {
                GameObject bulletcopy = Instantiate(bullet, pos.position, transform.rotation);
                currenttime = cooltime;
                animator.SetTrigger("Attack2");
            }
            if (Vector2.Distance(transform.position, right.collider.transform.position) < atkDistance)
            {
                if (AttackCoolTime < 0)
                {
                    animator.SetBool("Walk", false);
                    animator.SetTrigger("Attack");
                    AttackCoolTime = 1.5f;
                }
                //if (currenttime <= 0)
                //{
                //    GameObject bulletcopy = Instantiate(bullet, pos.position, transform.rotation);
                //    currenttime = cooltime;
                //    animator.SetTrigger("Attack2");
                //}
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, right.collider.transform.position, Time.deltaTime * speed);
                animator.SetBool("Walk", true);
            }
            currenttime -= Time.deltaTime;
        }

        RaycastHit2D left = Physics2D.Raycast(transform.position, transform.right * -1, distance, isLayer);
        if (left.collider != null)
        {
            sprite.flipX = false;
            if (currenttime <= 0)
            {
                GameObject bulletcopy = Instantiate(bullet, pos.position, transform.rotation);
                currenttime = cooltime;
                animator.SetTrigger("Attack2");
            }
            if (Vector2.Distance(transform.position, left.collider.transform.position) < atkDistance)
            {
                //if (currenttime <= 0)
                //{
                //    GameObject bulletcopy = Instantiate(bullet, pos.position, transform.rotation);
                //    currenttime = cooltime;
                //    animator.SetTrigger("Attack2");
                //}
                if (AttackCoolTime < 0)
                {
                    animator.SetBool("Walk", false);
                    animator.SetTrigger("Attack");
                    AttackCoolTime = 1.5f;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, left.collider.transform.position, Time.deltaTime * speed);
                animator.SetBool("Walk", true);
            }
            currenttime -= Time.deltaTime;
        }
    }
}

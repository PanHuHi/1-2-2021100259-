using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
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
        RaycastHit2D right = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if (right.collider != null)
        {
            if (Vector2.Distance(transform.position, right.collider.transform.position) < atkDistance)
            {
                sprite.flipX = true;
                animator.SetBool("Walk", false);
                if (currenttime <= 0)
                {
                    Invoke("BulletSpawn",1);
                    currenttime = cooltime;
                    animator.SetTrigger("Attack");
                    currenttime = 2.5f;
                }
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
            if (Vector2.Distance(transform.position, left.collider.transform.position) < atkDistance)
            {
                sprite.flipX = false;
                animator.SetBool("Walk", false);
                if (currenttime <= 0)
                {
                    Invoke("BulletSpawn",1);
                    currenttime = cooltime;
                    animator.SetTrigger("Attack");
                    currenttime = 2.5f;
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
    void BulletSpawn()
    {
        GameObject bulletcopy = Instantiate(bullet, pos.position, transform.rotation);
    }
}

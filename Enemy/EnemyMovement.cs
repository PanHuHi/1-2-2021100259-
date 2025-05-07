using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float distance;
    public float atkDistance;
    public LayerMask isLayer;
    public float speed;
    public Transform pos;
    SpriteRenderer sprite;
    public Animator animator;
    float AttackCoolTime = 1f;
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
            if (Vector2.Distance(transform.position, right.collider.transform.position) < atkDistance)
            {
                //sprite.flipX = true;
                if (AttackCoolTime < 0)
                {
                    animator.SetBool("Walk",false);
                    animator.SetTrigger("Attack");
                    AttackCoolTime = 1.5f;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, right.collider.transform.position, Time.deltaTime * speed);
                animator.SetBool("Walk", true);
            }
        }
        RaycastHit2D left = Physics2D.Raycast(transform.position, transform.right * -1, distance, isLayer);
        if (left.collider != null)
        {
            sprite.flipX = false;
            if (Vector2.Distance(transform.position, left.collider.transform.position) < atkDistance)
            {
                //sprite.flipX = false;
                if (AttackCoolTime < 0)
                {
                    animator.SetBool("Walk",false);
                    animator.SetTrigger("Attack");
                    AttackCoolTime = 1.5f;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, left.collider.transform.position, Time.deltaTime * speed);
                animator.SetBool("Walk", true);
            }
        }
     }
}
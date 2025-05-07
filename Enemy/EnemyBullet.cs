using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask isLayer;
    // public Transform target;
    Vector2 m_moveLimit = new Vector2(1000.0f, 0);
    GameObject enemy2;
    SpriteRenderer render;
    public Transform target;
    Player player;
    bool isLeftfire = false;
    bool isRightfire = false;
    public float damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        render = GameObject.Find("Enemy2").GetComponent<SpriteRenderer>();
        Invoke("DestroyBullet", 2);
        // if (AttackVector == 1)
        // {
        //     transform.rotation = Quaternion.Euler(0,0,180);
        // }
        if (render.flipX != true) // 적2의 flip이 true가 아닐때 (if문 한번만 실행해서 탄환의 방향이 추가로 변경되지 않음)
            isLeftfire = true; // 왼쪽 발사 실행
        else
            isRightfire= true; // 오늘쪽 발사 실행
    }

    // Update is called once per frame
    void Update()
    {
        // if (render.flipX == true)
        // {
        //     AttackVector = 1;
        // }
        // else
        // {
        //     AttackVector = 0;
        // }
        /*if (AttackVector == 1)
        {
            transform.rotation = Quaternion.Euler(0,0,180);
        }*/
        transform.LookAt(target);
        // RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.right * -1, distance, isLayer);
        // if (raycast.collider != null)
        // {
        //     if (raycast.collider.tag == "Player")
        //     {
        //         Debug.Log("-1 HP");
        //     }
        //     DestroyBullet();
        // }
        //transform.localPosition = ClampPosition(transform.localPosition);
        if (isLeftfire)
            Leftfire();
        else
            Rightfire();
        
    }
    public void Leftfire() // 왼쪽일때 실행
    {
        transform.Translate(Vector3.left * 3f * speed * Time.deltaTime);
    }
    public void Rightfire() // 오른쪽일때 실행
    {
        transform.Translate(Vector3.right * 3f * speed * Time.deltaTime);
    }
    
    /*public Vector3 ClampPosition(Vector3 position)
    {
        return new Vector3
        (
            Mathf.Clamp(position.x, -m_moveLimit.x, m_moveLimit.x),
            -3.068f, 0
        );
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
           collision.GetComponent<Player>().TakeDamage(damage);
           DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
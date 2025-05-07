using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask isLayer;
    // public Transform target;
    Vector2 m_moveLimit = new Vector2(1000.0f, 0);
    GameObject Boss;
    SpriteRenderer render;
    public Transform target;

    bool isLeftfire = false;
    bool isRightfire = false;
    public float damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        render = GameObject.Find("Boss").GetComponent<SpriteRenderer>();
        if (render.flipX != true) // ��2�� flip�� true�� �ƴҶ� (if�� �ѹ��� �����ؼ� źȯ�� ������ �߰��� ������� ����)
            isLeftfire = true; // ���� �߻� ����
        else
            isRightfire = true; // ������ �߻� ����


    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        if (isLeftfire)
            Leftfire();
        else
            Rightfire();

    }
    public void Leftfire() // �����϶� ����
    {
        transform.Translate(Vector3.left * 1f * speed * Time.deltaTime);
    }
    public void Rightfire() // �������϶� ����
    {
        transform.Translate(Vector3.right * 1f * speed * Time.deltaTime);
    }

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

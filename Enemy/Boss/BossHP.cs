using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    public float maxHP = 1000;
    public float currentHP;
    public GameObject fabric;
    public GameObject boss;
    public Transform bosspos;
    private SpriteRenderer spriteRanderer;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;
    // Start is called before the first frame update

    private void Awake()
    {
        currentHP = maxHP;
        spriteRanderer = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float damage)
    {
        currentHP = currentHP - damage;
        if ( currentHP <= 0 )
        {
            OnDie();
        }
    }
    public void OnDie()
    {
        Instantiate(fabric, bosspos.position, transform.rotation);
        if (gameObject.name =="Boss")
        {
            gameObject.GetComponent<BossMovement>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }   
        //gameObject.SetActive(false);
    }
}

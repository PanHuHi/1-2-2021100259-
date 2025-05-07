using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float maxHP;
    public float currentHP;
    private Enemy enemy;
    private SpriteRenderer spriteRenderer;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;
    private void Awake()
    {
        if (this.gameObject.name == "Boss")
        {
            maxHP = 1000;
        }
        else
        {
            maxHP = 100;
        }
        //maxHP = 100;
        currentHP = maxHP;
        enemy = GetComponent<Enemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    public void TakeDamage(float damage)
    {
        currentHP = currentHP - damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");
        if ( currentHP <= 0 )
        {
            OnDie();
        }
    }

    private IEnumerable HitColorAnimation()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = Color.white;
    }
    public void OnDie()
    {
        if (gameObject.name =="Enemy2")
        {
            gameObject.GetComponent<Enemy2>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (gameObject.name =="Enemy")
        {
            gameObject.SetActive(false);
        }
        //gameObject.SetActive(false);
    }
}

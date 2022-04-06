using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHP = 100;
    public int hp;

    public bool canTakeDmg = true;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            Die();
        }
    }

    public void Heal(int amt)
    {
        hp += amt;

        if (hp >= maxHP)
        {
            hp = maxHP;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

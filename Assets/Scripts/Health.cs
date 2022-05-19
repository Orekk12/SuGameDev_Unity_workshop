using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent OnGameOver;

    public int maxHP = 100;
    public int hp;
    public GameObject healthBar; 

    public bool canTakeDmg = true;

    public UITextElement healthUI;
    
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
    }

    void UpdateHealthBar(int dmg)
    {
        float oneHpScale = 0.100f / maxHP; //1 hp ye eşdeğer scale değişimini hesaplıyoruz
        healthBar.transform.localScale += Vector3.right * oneHpScale * dmg;
    }

    void SetHealthBar(int value)
    {
        var newX = 0.001f * value;
        healthBar.transform.localScale = new Vector3(newX, 0.01f, 1f);
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        UpdateHealthBar(-dmg);
        
        if (hp <= 0)
        {
            Die();
        }
    }

    public void Heal(int amt)
    {
        hp += amt;
        UpdateHealthBar(amt);
        
        if (hp >= maxHP)
        {
            SetHealthBar(maxHP);
            hp = maxHP;
        }
    }

    void Die()
    {
        OnGameOver?.Invoke();

        Destroy(gameObject);
    }
}

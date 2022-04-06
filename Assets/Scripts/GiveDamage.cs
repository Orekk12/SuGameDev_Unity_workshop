using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour
{
    public int damage = 1;

    public bool dieOnContact;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GiveDmg(damage, other.gameObject);
    }

    void GiveDmg(int dmg, GameObject other)
    {
        if (other.GetComponent<Health>())
        {
            other.GetComponent<Health>().TakeDamage(dmg);
            if (dieOnContact)
            {
                Destroy(gameObject);
            }
        }
    }
}

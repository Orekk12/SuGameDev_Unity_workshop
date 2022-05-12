using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RofPickup : MonoBehaviour
{
    public float rofIncrease = 0.2f;
    public float rofDuration = 2f;

    public bool isActive = true;

    private void OnTriggerEnter2D(Collider2D other)//ilk getcomponent ile sonra neden getcmpinchildren kullan�ld��n� anlat
    {
        if (other.gameObject.CompareTag("Player") && isActive)
        {
            StartCoroutine(IncreaseFireRate(other));
        }
    }

    IEnumerator IncreaseFireRate(Collider2D other)//ilk buray� yanl�� yap�p anlat, neden olmayaca��n� g�ster
    {
        PlayerShoot shootComponent = other.gameObject.GetComponentInChildren<PlayerShoot>();
        float defaultRof = shootComponent.fireRateCd;
        shootComponent.fireRateCd *= rofIncrease;

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        isActive = false;

        yield return new WaitForSeconds(rofDuration);

        shootComponent.fireRateCd = defaultRof;
        Destroy(gameObject);
    }
}

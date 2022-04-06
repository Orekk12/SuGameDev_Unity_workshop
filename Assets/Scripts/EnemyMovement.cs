using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    private GameObject player;
    void Start()
    {
        //player = FindObjectOfType<PlayerMovement>().gameObject;//ilk böyle, sonra deðiþecek
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        }
    }

    public void SetPlayer(GameObject obj)
    {
        player = obj;
    }
}

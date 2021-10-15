using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayKill : MonoBehaviour
{
    private bool falling = false;

    private PlayerControl pc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.transform.position.y < transform.position.y)
        {
            pc = collision.GetComponent<PlayerControl>();
            pc.Die();

        }
    }

    public bool IsFalling()
    {
        return falling;
    }

    public void SetFalling(bool falling)
    {
        this.falling = falling;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

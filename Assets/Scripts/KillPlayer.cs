using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private PlayerControl pc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pc = collision.GetComponent<PlayerControl>();
            pc.Die();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

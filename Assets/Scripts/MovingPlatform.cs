using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlatformRider pr;
        if (collision.gameObject.TryGetComponent<PlatformRider>(out pr))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        PlatformRider pr;
        if (collision.gameObject.TryGetComponent<PlatformRider>(out pr))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}

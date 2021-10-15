using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnSpikes : MonoBehaviour
{
    public float velocity = 0;

    private TriggerMovement trigger;
    private OneWayKill spikeCode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SpikePlat")
        {
            StartCoroutine(ReturnSpike(collision));
        }
    }

    private IEnumerator ReturnSpike(Collider2D collider)
    {
        yield return new WaitForSeconds(3f);

        trigger = collider.GetComponent<TriggerMovement>();
        spikeCode = collider.GetComponent<OneWayKill>();
        trigger.Activate(velocity, true, collider.transform.position.x, 5.5f);
        spikeCode.SetFalling(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

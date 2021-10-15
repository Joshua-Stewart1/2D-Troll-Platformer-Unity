using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public float velocity = 0;
    public bool isStoppable = false;
    public float goalX = 0;
    public float goalY = 0;
    public float sourceX = 0;
    public float sourceY = 0;

    public GameObject triggeredObj;

    private TriggerMovement trigger;

    // Start is called before the first frame update
    void Start()
    {
        trigger = triggeredObj.GetComponent<TriggerMovement>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.attachedRigidbody.velocity.y <= 0.5f)
        {
            trigger.Activate(velocity, isStoppable, goalX, goalY);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            trigger.Activate(velocity, true, sourceX, sourceY);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

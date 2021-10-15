using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
    public float velocity = 0;
    public bool isStoppable = false;
    public float goalX = 0;
    public float goalY = 0;

    public GameObject triggeredObj;

    private TriggerMovement trigger;

    // Start is called before the first frame update
    void Start()
    {
        trigger = triggeredObj.GetComponent<TriggerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            trigger.Activate(velocity, isStoppable, goalX, goalY);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMovement : MonoBehaviour
{
    private float velocity = 0;
    private bool isStoppable = false;
    private float goalX;
    private float goalY;

    private Vector3 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Activate(float velocity, bool isStoppable, float goalX, float goalY)
    {
        this.velocity = velocity;
        this.isStoppable = isStoppable;
        endPosition = new Vector3(goalX, goalY, 0);
        this.goalX = goalX;
        this.goalY = goalY;
    }

    // Update is called once per frame
    void Update()
    {
        if(isStoppable && transform.position != endPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, velocity * Time.deltaTime);
        }
        if(!isStoppable)
        {
            if(goalX != 0)
            {
                transform.position = transform.position + new Vector3(velocity * goalX,0,0) * Time.deltaTime;
            }
            else
            {
                transform.position = transform.position + new Vector3(0, velocity * goalY, 0) * Time.deltaTime;
            }
        }
    }
}

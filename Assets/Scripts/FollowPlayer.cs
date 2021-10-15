using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float xWindow;
    public float yWindow;
    public GameObject toFollow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position =
            new Vector3(
                Mathf.Clamp(transform.position.x,
                            toFollow.transform.position.x - xWindow,
                            toFollow.transform.position.x + xWindow),
                Mathf.Clamp(transform.position.y,
                            toFollow.transform.position.y - yWindow,
                            toFollow.transform.position.y + yWindow),
                transform.position.z);
    }
}

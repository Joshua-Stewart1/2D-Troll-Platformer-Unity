using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonOnDeath : MonoBehaviour
{
    public GameObject spawned;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Summon()
    {
        Instantiate(spawned, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

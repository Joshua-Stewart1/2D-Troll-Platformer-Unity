using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private ChangeScene cs;

    // Start is called before the first frame update
    void Start()
    {
        cs = GetComponentInParent<ChangeScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Start"))
        {
            cs.SceneChange();
        }
    }
}

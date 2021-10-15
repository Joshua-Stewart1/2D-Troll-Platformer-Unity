using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string nextRoom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SceneChange();
        }
    }

    public void SceneChange()
    {
        SceneManager.LoadScene(nextRoom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

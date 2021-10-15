using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        winText = GameObject.FindObjectOfType<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        Time.timeScale = 0;
        winText.text = "You defeated the evil programming student and acquired the Golden Quaternion!";
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

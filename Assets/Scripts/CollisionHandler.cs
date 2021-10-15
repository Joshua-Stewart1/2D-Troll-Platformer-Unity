using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private Tilemap theTilemap;
    public Tile spike;
    public Tile spikeDown;
    public Tile spikeLeft;
    public Tile spikeRight;
    private PlayerControl pc;

    // Start is called before the first frame update
    void Start()
    {
        theTilemap = GetComponent<Tilemap>();
    }

    public void HandleCollision(Vector2 point)
    {
        Vector3Int cellCoords = theTilemap.WorldToCell(point);
        TileBase tileAtCell = theTilemap.GetTile(cellCoords);
        if (tileAtCell == spike || tileAtCell == spikeDown || tileAtCell == spikeLeft || tileAtCell == spikeRight)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pc = collision.GetComponent<PlayerControl>();
            pc.Die();
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

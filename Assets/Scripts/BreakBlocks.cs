using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakBlocks : MonoBehaviour
{
    private Tilemap tm;

    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D[] contacts = collision.contacts;
        for (int i = 0; i < contacts.Length; i++)
        {
            if (collision.collider.tag == "Projectile")
            {
                HandleHit(contacts[i].point);
                HandleHit(contacts[i].point + new Vector2(0.1f, 0.1f));
                HandleHit(contacts[i].point + new Vector2(0.1f, -0.1f));
                HandleHit(contacts[i].point + new Vector2(-0.1f, 0.1f));
                HandleHit(contacts[i].point + new Vector2(-0.1f, -0.1f));
            }
        }
    }

    private void HandleHit(Vector2 point)
    {
        Vector3Int cellCoords = tm.WorldToCell(point);
        TileBase tileAtCell = tm.GetTile(cellCoords);
        tm.SetTile(cellCoords, null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

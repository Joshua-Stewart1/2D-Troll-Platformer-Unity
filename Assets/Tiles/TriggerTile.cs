using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TriggerTile : Tile
{
    // Start is called before the first frame update

    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
       tileData.sprite = this.sprite;
       tileData.color = this.color;
       tileData.transform = this.transform;
       tileData.gameObject = this.gameObject;

        tileData.flags = this.flags;
        tileData.colliderType = Tile.ColliderType.Grid;
    }

    #if UNITY_EDITOR
// The following is a helper that adds a menu item to create a TriggerTile Asset
    [MenuItem("Assets/Create/TriggerTile")]
    public static void CreateTriggerTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Trigger Tile", "New Trigger Tile", "Asset", "Save Trigger Tile", "Assets");
        if (path == "")
            return;
    AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<TriggerTile>(), path);
    }
#endif
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateSprites : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] _itemPrefabs = new GameObject[1];

    public void CheckItemsAndCreate()
    {
        for (int i = 0; i < _itemPrefabs.Length; i++)
        {
           
            CreateSpritesFast(_itemPrefabs[i]);

        }
    }
   
    void CreateSpritesFast(GameObject _data)
    {
        string fileName = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(_data)) + ".png";
        string astPath = "Assets/Prefabs/snapshots/" + fileName;
        fileName = Application.dataPath + "/Prefabs/snapshots/" + fileName;
        FileInfo info = new FileInfo(fileName);
        if (info.Exists)
            File.Delete(fileName);
        else if (!info.Directory.Exists)
            info.Directory.Create();

        Texture2D tex = AssetPreview.GetAssetPreview(_data);
        File.WriteAllBytes(fileName, tex.EncodeToPNG());

        //ShopItem data;
        //data.artWork = astPath
        /*
        Sprite mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        _data.artWork = mySprite;
        */
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class PrefabShot : MonoBehaviour
{
   
    
    public GameObject _shotPlace;

    public GameObject _obj;

    public void CreateObj()
    {
        
        GameObject ins = GameObject.Instantiate(_obj, _shotPlace.transform, false);

        ins.GetComponent<Rigidbody>().useGravity = false;

        ins.transform.position = new Vector3(0, 0, 10);

        ins.SetActive(true);
    }

    public void ShotObject()
    {
        DoSnapshot(_obj);
       
    }

    private static void DoSnapshot(GameObject go)
    {
       
        string fileName = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(go)) + ".png";
        string astPath = "Assets/Prefabs/snapshots/" + fileName;
        fileName = Application.dataPath + "/Prefabs/snapshots/" + fileName;
        FileInfo info = new FileInfo(fileName);
        if (info.Exists)
            File.Delete(fileName);
        else if (!info.Directory.Exists)
            info.Directory.Create();
        ScreenCapture.CaptureScreenshot(fileName);

    }


}

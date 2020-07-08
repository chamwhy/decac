using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public struct TileInfo
{
    public GameObject tile;
    public int rotation;
    public Color tileColor;

}

public class LvlEditor : MonoBehaviour
{
    public Texture2D[] map;
    private Texture2D userMap;
    public GameObject mapParent;

    
    
    public TileInfo[] tileInfos;

    private void Start()
    {
        GenerateMap(0);
    }

    public void GetUserMap(string mapID)
    {
        userMap = new Texture2D(1, 1);
    }

    public void GenerateMap(int index)
    {
        Texture2D nowMap = map[index];
        for (int x = 0; x < nowMap.width; x++)
        {
            for(int y = 0; y < nowMap.height; y++)
            {
                GenerateTile(index, x, y);
            }
        }
    }

    private void GenerateTile(int index,int x, int y)
    {
        Texture2D nowMap = map[index];
        Color color = nowMap.GetPixel(x, y);
        if(color.a != 0)
        {
            for (int i = 0; i < tileInfos.Length; i++)
            {
                if (color == tileInfos[i].tileColor)
                {
                    Instantiate(tileInfos[i].tile, new Vector2(x - 5, y)*0.4f, Quaternion.Euler(0, 0, tileInfos[i].rotation), mapParent.transform);
                    break;
                }
            }
        }
    }
}

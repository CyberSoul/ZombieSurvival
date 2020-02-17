using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] MapGeneratorItem[] m_items;
    [SerializeField] Texture2D m_testMap;
   // [SerializeField] NavMesh m_surface;

    // Start is called before the first frame update
    void Start()
    {
        LoadMap(m_testMap);
        NavMeshBuilder.BuildNavMeshData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadMap( Texture2D a_map)
    {
        for (int i = 0; i < a_map.width; ++i)
        {
            for (int j = 0; j < a_map.height; ++j)
            {
                Color testColor = a_map.GetPixel(i, j);
                LoadMapTile(i, j, a_map.GetPixel(i, j));
                //Debug.Log($"Color = {testColor} at position {i},{j}");
            }
        }


    }

    private void LoadMapTile(int a_posX, int a_posZ, Color a_color)
    {
        for (int i = 0; i < m_items.Length; ++i)
        {
            if ( m_items[i].m_color.Equals( a_color ) )
            {
                Vector3 position = new Vector3(a_posX, 0, a_posZ);
                var mapTile = Instantiate(m_items[i].m_prefab, position, Quaternion.identity, transform);
                break;
            }
        }
    }

    private void SaveMap()
    {

    }
}

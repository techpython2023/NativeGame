using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    //create referance to base game object
    public GameObject[] tilePrfabs;
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numtiles = 5;
    public Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject> ();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numtiles; i++)
        {
            if (i == 0)
            {
                spawnTile(0);
            }
            else
            {
                spawnTile(Random.Range(0, tilePrfabs.Length));
            }
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - 35 > zSpawn-(numtiles*tileLength))
        {
            spawnTile(Random.Range(0, tilePrfabs.Length));
            deleteTile();
        }
        
    }

    //Intantiate tile
    public void spawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrfabs[tileIndex],transform.forward*zSpawn,transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }
    private void deleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}

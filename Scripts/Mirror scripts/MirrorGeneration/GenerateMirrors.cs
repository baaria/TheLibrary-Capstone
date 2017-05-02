using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class MirrorTile
{
    public GameObject theMirrorTile;
    public float timeSinceCreated;

    public MirrorTile(GameObject m, float tc)
    {
        theMirrorTile = m;
        timeSinceCreated = tc;
    }
}

public class GenerateMirrors : MonoBehaviour {

    public GameObject mirrorPlane;
    public GameObject player;

    int mirrorPlaneSize = 20;
    int halfTilesX = 3;
    int halfTilesZ = 3;

    Vector3 startPos;

    Hashtable mirrorsTable = new Hashtable();


	// Use this for initialization
	void Start () {
        this.gameObject.transform.position = Vector3.zero;
        float updateTime = Time.realtimeSinceStartup;
        for (int x = -halfTilesX; x < halfTilesX; x++)
        {
            for(int z = -halfTilesZ; z < halfTilesZ; z++)
            {
                Vector3 pos = new Vector3((x * mirrorPlaneSize + startPos.x), 0, (z * mirrorPlaneSize + startPos.z));
                GameObject m = (GameObject)Instantiate(mirrorPlane, pos, Quaternion.identity);
                string MirrorName = "Mirror_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                m.name = MirrorName;
                MirrorTile mirrorTile = new MirrorTile(m, updateTime);
                mirrorsTable.Add(MirrorName, mirrorTile);

            }
        }	
	}
	
	// Update is called once per frame
	void Update () {
        //determine how far player has moved since last update
        int xMove = (int)(player.transform.position.x - startPos.x);
        int zMove = (int)(player.transform.position.z - startPos.z);

        if (Mathf.Abs(xMove) >= mirrorPlaneSize || Mathf.Abs(zMove) >= mirrorPlaneSize)
        {
            float updateTime = Time.realtimeSinceStartup;

            //force integer position + round to nearest tilesize
            int playerX = (int)(Mathf.Floor(player.transform.position.x / mirrorPlaneSize) * mirrorPlaneSize);
            int playerZ = (int)(Mathf.Floor(player.transform.position.z / mirrorPlaneSize) * mirrorPlaneSize);

            for(int x = -halfTilesX; x < halfTilesX; x++)
            {
                for(int z = -halfTilesZ; z < halfTilesZ; z++)
                {
                    Vector3 pos = new Vector3((x * mirrorPlaneSize + playerX), 0, (z * mirrorPlaneSize * playerZ));
                    string mirrorName = "Mirror" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                    if(!mirrorsTable.ContainsKey(mirrorName))
                    {
                        GameObject m = (GameObject)Instantiate(mirrorPlane, pos, Quaternion.identity);
                        m.name = mirrorName;
                        MirrorTile mirrorTile = new MirrorTile(m, updateTime);
                        mirrorsTable.Add(mirrorName, mirrorTile);
                    } else
                    {
                        (mirrorsTable[mirrorName] as MirrorTile).timeSinceCreated = updateTime;
                    }
                }

            }

            //destroy all tiles not just created or with time updated
            //and put all new tiles and tiles to be kept in a new hashtable
            Hashtable newMirrorsTable = new Hashtable();
            foreach(MirrorTile mtls in mirrorsTable.Values)
            {
                if(mtls.timeSinceCreated != updateTime)
                {
                    //DELETE Gameobject. It has been deemed unncessary
                    Destroy(mtls.theMirrorTile);

                } else
                {
                    newMirrorsTable.Add(mtls.theMirrorTile.name, mtls);
                }

                //copy new hashtable contents to working hashtable
                mirrorsTable = newMirrorsTable;
                startPos = player.transform.position;

            }
        }
	}
}

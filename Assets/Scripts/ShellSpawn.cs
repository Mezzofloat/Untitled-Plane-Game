using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSpawn : MonoBehaviour
{
    [SerializeField] GameObject shell;
    [SerializeField] int numShells;
    [SerializeField] CompositeCollider2D tilemap;
    
    #nullable enable
    public static List<Transform>? shells {get; set;}

    // Start is called before the first frame update
    void Awake()
    {
        tilemap.geometryType = CompositeCollider2D.GeometryType.Polygons;
        float x,y;

        shells = new List<Transform>();

        for (int i = 0; i < numShells; i++) {
            x = Random.Range(-17f/2, 17f/2);
            y = Random.Range(-9f/2, 9f/2);
            Vector3 position = new Vector3(x,y);

            if (tilemap.OverlapPoint(position)) {
                GameObject newShell = Instantiate(shell, position, Quaternion.identity);
                shells.Add(newShell.transform);
            } else {
                i--;
            }
        }

        tilemap.geometryType = CompositeCollider2D.GeometryType.Outlines;
    }
}

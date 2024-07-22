using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnValuables : MonoBehaviour
{
    [SerializeField] GameObject shell, pearl, sand;
    [SerializeField] int numShells, numPearls, numSand;
    [SerializeField] CompositeCollider2D tilemap;

    
    #nullable enable
    public static List<Transform> shells {get; set;} = new();
    public static List<Transform> pearls {get; set;} = new();
    public static List<Transform> sands {get; set;} = new();

    // Dictionary<GameObject, (List<Transform>, int)> valuableDictionary = new() {
    //     { shell, (shells, numShells)},
    //     { pearl, (pearls, numPearls)}
    // };

    // Start is called before the first frame update
    void Awake()
    {
        tilemap.geometryType = CompositeCollider2D.GeometryType.Polygons;

        shells = new List<Transform>();
        pearls = new List<Transform>();
        sands = new List<Transform>();

        Spawn(shell, numShells);
        Spawn(pearl, numPearls);
        Spawn(sand, numSand);

        tilemap.geometryType = CompositeCollider2D.GeometryType.Outlines;
    }

    void Spawn(GameObject obj, int num) {
        float x,y;

        List<Transform> objs = new();

        if (obj == pearl) objs = pearls;
        else if (obj == shell) objs = shells;
        else if (obj == sand) objs = sands;

        for (int i = 0; i < num; i++) {
            x = Random.Range(-17f/2, 17f/2);
            y = Random.Range(-9f/2, 9f/2);
            Vector3 position = new(x,y);

            if (tilemap.OverlapPoint(position)) {
                GameObject newValuable = Instantiate(obj, position, Quaternion.identity);
                objs.Add(newValuable.transform);
            } else {
                i--;
            }
        }
    }
}

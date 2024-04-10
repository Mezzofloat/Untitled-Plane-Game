using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMap : MonoBehaviour
{
    [SerializeField] GameObject map;
    [SerializeField] Transform plane, player;

    void OnMap() {
        if ((plane.position - player.position).sqrMagnitude < 3 && map.activeSelf == false) {
            map.SetActive(true);
        } else {
            map.SetActive(false);
        }
    }
}

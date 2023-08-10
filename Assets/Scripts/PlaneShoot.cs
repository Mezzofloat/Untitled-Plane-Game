using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletLocation;
    [SerializeField] int maxBullets;
    [SerializeField] TMP_Text bulletNum;

    int numBullets;

    void Awake()
    {
        numBullets = maxBullets;
        bulletNum.text = numBullets.ToString() + "/" + maxBullets.ToString();
    }

    void OnShoot() {
        if (numBullets > 0) {
            Instantiate(bulletPrefab, bulletLocation.transform.position, bulletLocation.transform.rotation);
            numBullets--;
            bulletNum.text = numBullets.ToString() + "/" + maxBullets.ToString();
        }
    }

    void OnBackshoot() {
        Quaternion backwards = Quaternion.Euler(bulletLocation.transform.rotation.eulerAngles.x,bulletLocation.transform.rotation.eulerAngles.y + 180,bulletLocation.transform.rotation.eulerAngles.z);
        if (numBullets > 0) {
            Instantiate(bulletPrefab, bulletLocation.transform.position, backwards);
            numBullets--;
            bulletNum.text = numBullets.ToString() + "/" + maxBullets.ToString();
        }
    }

    void OnResetBullets() {
        numBullets = maxBullets;
        bulletNum.text = numBullets.ToString() + "/" + maxBullets.ToString();
    }
}

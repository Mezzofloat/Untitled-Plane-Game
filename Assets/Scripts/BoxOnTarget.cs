using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOnTarget : MonoBehaviour
{
    [SerializeField] Transform player;

    #nullable enable
    Transform? boxOnTarget;

    void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Box")) {
            boxOnTarget = other.transform;
        }
    }

    void FixedUpdate()
    {
        if (boxOnTarget != null) {
            if ( (boxOnTarget.position - transform.position).sqrMagnitude < 0.25f ) {
                boxOnTarget.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                boxOnTarget.gameObject.layer = 0;
                StartCoroutine(RotateToZero(boxOnTarget));

                player.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                player.position -= (boxOnTarget.position - player.position) * 0.7f;
                player.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }
        }
    }

    IEnumerator RotateToZero(Transform box) {
        Quaternion startRotation = box.rotation;
        float endZRot = 0f;
        float t = 0;

        while (Mathf.Abs(box.eulerAngles.z) > 0.01)
        {
            t = Mathf.Min(1f, t + Time.deltaTime/5 * Mathf.Abs(box.eulerAngles.z));
            Vector3 angleToRotate = new Vector3(0, 0, Mathf.LerpAngle(box.eulerAngles.z, endZRot, t));
            box.eulerAngles = angleToRotate;
            yield return null;
        } 
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == boxOnTarget) {
            boxOnTarget = null;
        }
    }
}

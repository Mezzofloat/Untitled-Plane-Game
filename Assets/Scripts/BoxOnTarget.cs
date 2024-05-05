using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class BoxOnTarget : MonoBehaviour
{
    [SerializeField] float timeToEnd = 0.65f;
    [SerializeField] UnityEvent boxEnded;

    Transform boxOnTarget;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Box")) {
            boxOnTarget = other.transform;
            StartCoroutine(nameof(EndBox));
        }
    }

    IEnumerator EndBox() {
        while ( (boxOnTarget.position - transform.position).sqrMagnitude >= 0.25f ) {
            yield return null;
        }

        boxOnTarget.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        boxOnTarget.gameObject.layer = 0;
        boxOnTarget.DORotate(Vector3.zero, timeToEnd);
        boxOnTarget.DOMove(transform.position, timeToEnd).SetEase(Ease.OutSine);
        boxEnded.Invoke();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == boxOnTarget) {
            boxOnTarget = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardFlip2 : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public float targetRotation = 360.0f;
    public float flipDuration = 1.0f;

    private bool isFlipping = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isFlipping)
        {
            StartCoroutine(FlipCard());
        }
    }

    private IEnumerator FlipCard()
    {
        isFlipping = true;

        Quaternion startRotation = transform.rotation;
        Quaternion targetQuaternion = Quaternion.Euler(0, targetRotation, 0);
        float t = 0.0f;

        while (t < 1.0f)
        {
            t += Time.deltaTime / flipDuration;
            transform.rotation = Quaternion.Lerp(startRotation, targetQuaternion, t * rotationSpeed);
            yield return null;
        }

        isFlipping = false;
    }
}

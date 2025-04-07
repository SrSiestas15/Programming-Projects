using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    Vector3 bubbleTransform = Vector3.zero;
    float verticalOffset;
    public bool inverse;

    void Start()
    {
        bubbleTransform.x = transform.localPosition.x - 3.45f;
        verticalOffset = transform.localPosition.y;
    }

    void Update()
    {
        bubbleTransform.x -= Time.deltaTime * 3;    
        bubbleTransform.y = (Mathf.Sin(bubbleTransform.x) * 4) - verticalOffset;
        if (inverse)
        {
            bubbleTransform.y *= -1;
        }

        transform.localPosition = bubbleTransform;
    }
}

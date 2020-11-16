using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public GameObject cam;

    public CircleCollider2D colliderCircle;

    public moveCamera mC;

    public bool firstTime = true;

    void Awake()
    {
        Debug.Log("spawned");
        colliderCircle.enabled = true;
        mC.enabled = true;
    }

    void OnTriggerEnter2D()
    {
        Camera cam = (Camera)FindObjectOfType(typeof(Camera));
        Vector3 target = new Vector3(0, cam.transform.position.y + 5, -10);
        cam.transform.position = target;
        mC.enabled = false;
        colliderCircle.enabled = false;
    }
}

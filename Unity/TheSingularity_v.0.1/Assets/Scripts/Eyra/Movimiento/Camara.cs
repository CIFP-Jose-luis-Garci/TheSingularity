using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    Vector3 cameraDirection;
    float camDistance;
    Vector2 cameraDistanceMinMax = new Vector2(0.5f, 5f);
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        cameraDirection = cam.transform.localPosition.normalized;
        camDistance = cameraDistanceMinMax.y;
    }

    // Update is called once per frame
    void Update()
    {
        CheckCameraOcclusionAndCollision(cam);
    }
    public void CheckCameraOcclusionAndCollision(Transform cam)
    {
        Vector3 desiredCameraPosition = transform.TransformPoint(cameraDirection * cameraDistanceMinMax.y);
        RaycastHit hit;
        if(Physics.Linecast(transform.position, desiredCameraPosition, out hit))
        {
            camDistance = Mathf.Clamp(hit.distance, cameraDistanceMinMax.x, cameraDistanceMinMax.y);
        }
        else
        {
            camDistance = cameraDistanceMinMax.y;
        }
        cam.localPosition = cameraDirection * camDistance;
    }
}

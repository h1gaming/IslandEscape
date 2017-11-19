using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour {

    public Transform characterPosition;
    private float distance;
    public float centerHeight;
    public float viewDirection;
    private Vector3 offset;
    private Vector3 centerHeightVector;
    private Vector3 viewRotationVector;
    Quaternion direction;


    private void Start()
    {
        offset = new Vector3(0.0f, 10.0f, -10.0f);
        centerHeightVector = new Vector3(0.0f, centerHeight, 0.0f);
        distance = 0.7f;
        viewDirection= 45.0f;
        viewRotationVector = new Vector3(viewDirection, 0.0f, 0.0f);
        direction = Quaternion.Euler(viewRotationVector);
}


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
            {
                viewDirection -= 2.5f;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
            {
                viewDirection += 2.5f;
            }
        }
        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
            {
                distance /= 1.1f;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
            {
                distance *= 1.1f;
            }
        }

        centerHeight = Mathf.Max(0.0f, centerHeight);
        centerHeightVector.y = centerHeight;
        distance = Mathf.Min(Mathf.Max(distance,0.2f), 3.0f);
        viewDirection = Mathf.Min(Mathf.Max(viewDirection, 0.0f), 60.0f);

        viewRotationVector.x = viewDirection;
        direction = Quaternion.Euler(viewRotationVector);
    }

    private void LateUpdate()
    {
        gameObject.transform.SetPositionAndRotation(characterPosition.transform.position + centerHeightVector + offset*distance, direction);
    }
}

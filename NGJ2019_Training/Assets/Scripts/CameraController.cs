using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : GameControllerCommunicator
{
    public GameController Controller;
    public float HightFloatHighestPoint = 5;

    // Screen shake effect
    private Transform transform;
    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.15f;
    private float dampingSpeed = 2.0f;
    Vector3 initialPosition;

    void Awake()
    {
        Controller = GameObject.FindObjectOfType<GameController>();

        transform = GetComponent(typeof(Transform)) as Transform;
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;

            var position = this.transform.position;
            position = new Vector3(position.x, Controller.CurrentHighPoint + HightFloatHighestPoint, position.z);
            if (position.y < 10)
            {
                return;
            }
            this.transform.position = Vector3.Slerp(this.transform.position, position, 0.15f * Time.deltaTime);
        }
    }

    public void ShakeCamera()
    {
        shakeDuration = 0.10f;
    }
}

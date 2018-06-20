using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int bufferFrames = 300;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private bool fire1Clicked = false;
    private int frameClicked;

    private Rigidbody rBody;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rBody = GetComponent<Rigidbody>();    
    }

    private void Update()
    {
        if (gameManager.recording)
        {
            Record();
            fire1Clicked = false;
        } else
        {
            PlayBack();
        }
    }

    private void Record()
    {
        rBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }

    private void PlayBack()
    {
        int frame;
        rBody.isKinematic = true;
        if (Time.frameCount < bufferFrames && !fire1Clicked)
        {
            frameClicked = Time.frameCount;
            fire1Clicked = true;
        }
        if (fire1Clicked)
        {
            frame = Time.frameCount % frameClicked;
        }
        else
        {
            frame = Time.frameCount % bufferFrames;
        }
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }
}

/// <summary>
/// A structure for storing time, position and rotation.
/// </summary>
public struct MyKeyFrame
{
    public float time;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(float outTime, Vector3 outPosition, Quaternion outRotation)
    {
        time = outTime;
        position = outPosition;
        rotation = outRotation;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int bufferFrames = 1000;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody objRigidbody;
    private GameManager gamemanager;

	// Use this for initialization
	void Start () {
        objRigidbody = GetComponent<Rigidbody>();
        gamemanager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gamemanager.recording)
        {
            Record();
        } else
        {
            Playback();
        }
    }

    void Playback()
    {
        objRigidbody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        print("Reading frame " + frame);
        transform.position = keyFrames[frame].kfPosition;
        transform.rotation = keyFrames[frame].kfRotation;
    }

    void Record()
    {
        objRigidbody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        print("Writing frame " + frame);
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}

/// <summary>
/// A structure to store time, position and rotation.
/// </summary>
public struct MyKeyFrame
{
    public float kfTime;
    public Vector3 kfPosition;
    public Quaternion kfRotation;
    
    public MyKeyFrame(float time, Vector3 pos, Quaternion rotation)
    {
        kfTime = time;
        kfPosition = pos;
        kfRotation = rotation;
    }
}

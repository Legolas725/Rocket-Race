 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float mainRotate = 100f;
    [SerializeField] AudioClip engine;
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] ParticleSystem Mainboost;
    [SerializeField] ParticleSystem Leftboost;
    [SerializeField] ParticleSystem Rightboost;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame[
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        
    }
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime );
            Debug.Log("pressed space- thrust");
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(engine);
            }
            if (!Mainboost.isPlaying)
            {
                Mainboost.Play();
            }
        }
        else
        {
            audioSource.Stop();
            Mainboost.Stop();
        }
        
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(mainRotate);
            if (!Leftboost.isPlaying)
            {
                Leftboost.Play();
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(- mainRotate);
            if (!Rightboost.isPlaying)
            {
                Rightboost.Play();
            }
        }
        else
        {
            Leftboost.Stop();
            Rightboost.Stop();
        }
    }
    void ApplyRotation(float rotationthisframe)
    {
        rb.freezeRotation = true;

        transform.Rotate(Vector3.forward * rotationthisframe * Time.deltaTime);

        rb.freezeRotation = false;
    }

}

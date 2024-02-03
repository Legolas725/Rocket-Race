using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{
    [SerializeField]  float Loadleveldelay =2f;
    [SerializeField] float Reloadlevel;
    [SerializeField] AudioClip Crash;
    [SerializeField] AudioClip Finishline;

    [SerializeField] ParticleSystem CrashParticle;
    [SerializeField] ParticleSystem FinishParticle;


    AudioSource Audiosource;
    bool stillgoing = false;
    bool CollisionDisabled = false;

    void Start()
    {
        Audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        RespondToKeys();
        
    }

    void RespondToKeys()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Loadnextlevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            CollisionDisabled = !CollisionDisabled;
        }
        else if (Input.GetKey(KeyCode.B))
        {
            CrashSequence();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (stillgoing || CollisionDisabled)
        {
            return;
        }
        switch (other.gameObject.tag)
        {
            
            case "Start":
                Debug.Log("this is starting point");
                break;
            case "Finish":
                SuccesSequence();
                break;
            case "Fuel":
                Debug.Log("fueled up ");
                break;
            default:
                CrashSequence();
                break;

              
        }
    }

    void CrashSequence()
    {

        stillgoing = true;
        GetComponent<Movement>().enabled = false;
        //GetComponent<AudioSource>().enabled = false;
        CrashParticle.Play();

        Audiosource.Stop();
        Invoke("ReloadLevel", Reloadlevel);
        Audiosource.PlayOneShot(Crash);
    }

    void SuccesSequence()
    {
        stillgoing = true;
        GetComponent<Movement>().enabled = false;
        //GetComponent<AudioSource>().enabled = false;
        FinishParticle.Play();

        Audiosource.Stop();
        Invoke("Loadnextlevel", Loadleveldelay);
        Audiosource.PlayOneShot(Finishline);


    }



    void Loadnextlevel()
    {
        int currentSceaneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextsceaneindex = currentSceaneIndex + 1;

        if
            (nextsceaneindex == SceneManager.sceneCountInBuildSettings)
        {
            nextsceaneindex = 0;
        }

        
        SceneManager.LoadScene(nextsceaneindex);
    }
    void ReloadLevel()
    {
        int currentSceaneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceaneIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatsCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.P))
        {
            PreviousLevel();
        }
        if (Input.GetKey(KeyCode.N)) {
            NextLEvel();
        }

            
        
    }

    void NextLEvel()
    {

        {
            
            
                int currentSceaneIndex = SceneManager.GetActiveScene().buildIndex;

                int nextsceaneindex = currentSceaneIndex + 1;

                if
                    (nextsceaneindex == SceneManager.sceneCountInBuildSettings)
                {
                    nextsceaneindex = 0;
                }


                SceneManager.LoadScene(nextsceaneindex);
             ;
        }
    }

    void PreviousLevel()
    {

        int currentSceaneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextsceaneindex = currentSceaneIndex - 1;

        if
            (nextsceaneindex == SceneManager.sceneCountInBuildSettings)
        {
            nextsceaneindex = 0;
        }


        SceneManager.LoadScene(nextsceaneindex);
        ;
    }
}

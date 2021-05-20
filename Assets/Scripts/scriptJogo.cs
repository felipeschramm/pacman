using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptJogo : MonoBehaviour
{
    public bool pausa = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa)
            {
                SceneManager.UnloadSceneAsync(2);
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
                SceneManager.LoadScene(2, LoadSceneMode.Additive);

            }
            pausa = !pausa;
        }

    }
}

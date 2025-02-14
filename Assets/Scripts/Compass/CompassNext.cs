using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompassNext : MonoBehaviour
{
    public string sceneToLoad;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            Debug.Log("Player entered the door trigger!");

            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

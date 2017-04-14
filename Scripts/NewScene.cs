using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class NewScene : MonoBehaviour {

    public Rigidbody lightstick1, lightstick2;


    private void OnTriggerEnter(Collider other)
    {
        if (!(lightstick1.isKinematic || lightstick2.isKinematic)) {
            GameObject[] gos;
            //get all the objects with the tag "myTag"
            gos = GameObject.FindGameObjectsWithTag("Scene2");
            //loop through the returned array of game objects and set each to active false
            foreach (GameObject go in gos)
            {
                go.SetActive(true);
            }
            SceneManager.LoadScene("Scene 2");
    }
	}
}

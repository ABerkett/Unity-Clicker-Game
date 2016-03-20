using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CustomButtonScript : MonoBehaviour {

    int sceneToLoad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadScene1()
    {
        SceneManager.LoadScene(1);
    }
}

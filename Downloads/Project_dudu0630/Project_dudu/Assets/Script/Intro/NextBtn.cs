using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextBtn : MonoBehaviour {
    

    

    public void click()
    {
        SceneManager.LoadScene("Lobby");
    }
    
   

    // Use this for initialization
    void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

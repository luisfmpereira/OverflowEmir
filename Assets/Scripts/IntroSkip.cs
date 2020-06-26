using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSkip : MonoBehaviour
{

	public bool canSkip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(canSkip && Input.GetKeyDown(KeyCode.P))
		{
			SceneManager.LoadScene(1);
		}
    }
}

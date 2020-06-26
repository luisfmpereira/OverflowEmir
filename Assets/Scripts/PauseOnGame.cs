using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseOnGame : MonoBehaviour
{
	public GameObject options;
	private AudioManager audioManager;
	public GameObject count;
	public GameObject dialogo;
	public bool isLevel;

	private void Awake()
	{
		audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }



	public void continueButton()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		Time.timeScale = 1;
		dialogo.SetActive(true);
		if(isLevel)
		count.SetActive(true);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			options.SetActive(true);
			Time.timeScale = 0;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			dialogo.SetActive(false);
			if(isLevel)
			count.SetActive(false);
			audioManager.StopSound("Steps");
		}
	}

	public void MainMenuButton()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
		audioManager.StopSound("WindDesert");
	}
}

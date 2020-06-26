using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMenu : MonoBehaviour
{
	public GameObject mainMenu1;
	public GameObject mainMenu2;

	// Start is called before the first frame update

	private void Awake()
	{
		if (PlayerPrefs.HasKey("PlayedTutorial"))
		{
				mainMenu1.SetActive(false);
				mainMenu2.SetActive(true);
		}
	}

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha9))
		{
			PlayerPrefs.DeleteAll();
		}
	}

	public void StartGame()
	{
		SceneManager.LoadScene("Hub");
	}

	public void StartIntro()
	{
		SceneManager.LoadScene(5);
	}

	public void StartGameNewGame()
	{
		PlayerPrefs.DeleteKey("PlayedTutorial");

		if (PlayerPrefs.HasKey("SetSpawnHub"))
		{
			PlayerPrefs.DeleteKey("SetSpawnHub");
		}



		for (int i = 0; i < 20; i++)
		{
			if(PlayerPrefs.HasKey("Dialogo" + i))
			{
				PlayerPrefs.DeleteKey("Dialogo" + i);
			}
		}

		SceneManager.LoadScene(5);
	}

	public void BackButton()
	{
		if (PlayerPrefs.HasKey("PlayedTutorial"))
		{
			if (PlayerPrefs.GetInt("PlayedTutorial") == 1)
			{
				mainMenu1.SetActive(false);
				mainMenu2.SetActive(true);
			}
		}

		else
		{
			mainMenu1.SetActive(true);
			mainMenu2.SetActive(false);
		}
	}

	public void ExitGame()
	{
		Application.Quit();
	}

}

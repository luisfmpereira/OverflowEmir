using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttMusicVolume : MonoBehaviour
{
	public AudioSource musicMenu;
	public bool isMenuSound;
	public bool isSliderMusic;
	public bool isSliderEffect;
	public bool isOnMenu;

    // Start is called before the first frame update
    void Start()
    {
		if (isSliderMusic)
			this.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume")*2;
		if (isSliderEffect)
			this.GetComponent<Slider>().value = PlayerPrefs.GetFloat("EffectsVolume");
	}

    // Update is called once per frame
    void Update()
    {
		if (isMenuSound)
		{
			if(PlayerPrefs.HasKey("MusicVolume"))
			musicMenu.volume = PlayerPrefs.GetFloat("MusicVolume");
		}
	}

	public void UpdateAudioMenu()
	{
		PlayerPrefs.SetFloat("MusicVolume", this.GetComponent<Slider>().value / 2 );
		if (isOnMenu) 
		musicMenu.volume = this.GetComponent<Slider>().value / 2;
	}

	public void UpdateLevelSound()
	{
		PlayerPrefs.SetFloat("EffectsVolume", this.GetComponent<Slider>().value);
	}


}

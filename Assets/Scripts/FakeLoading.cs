using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeLoading : MonoBehaviour
{
	public int timeToWait;
	private void Awake()
	{
			this.gameObject.SetActive(true);
			StartCoroutine(WaitToShowGameplay());
			Global.isPaused = true;
	}
	// Start is called before the first frame update
	void Start()
    {

    }

	IEnumerator WaitToShowGameplay()
	{
		yield return new WaitForSeconds(timeToWait);
		this.gameObject.SetActive(false);
		Global.isPaused = false;
	}
}

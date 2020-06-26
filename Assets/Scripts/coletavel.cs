using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coletavel : MonoBehaviour
{
    private GotaController gotaController;
	AudioManager audioManager;
    public GameObject particle;

    private void Awake()
    {
        gotaController = GameObject.Find("PortaoFinal").GetComponent<GotaController>();
		audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
       
	}
    // Update is called once per frame
    void Update()
    {
		this.transform.Rotate(Vector3.up, 30 * Time.deltaTime);
    }

	void OnTriggerEnter(Collider col)
	{
		if(col.CompareTag("Player"))
		{
            gotaController.actualQuantity += 1;
			gotaController.UpdateCounterText();
			audioManager.PlaySound("Collect");
            GameObject x = Instantiate(particle, col.transform.position, Quaternion.identity);
            x.transform.SetParent(col.transform);
            Destroy(this.gameObject);
		}
	}
}

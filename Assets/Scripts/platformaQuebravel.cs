using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformaQuebravel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			StartCoroutine(Broke());
		}
	}

	IEnumerator Broke()
	{
		yield return new WaitForSeconds(2);
		this.GetComponent<MeshRenderer>().enabled = false;
		this.GetComponent<BoxCollider>().enabled = false;
		//this.GetComponentInChildren<BoxCollider>().enabled = false;
		this.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
		yield return new WaitForSeconds(4);
		this.GetComponent<MeshRenderer>().enabled = true;
		this.GetComponent<BoxCollider>().enabled = true;
		//this.GetComponentInChildren<BoxCollider>().enabled = true;
		this.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsRoll : MonoBehaviour
{
    public void LoadGame() => SceneManager.LoadScene(0);

    private void Update()
    {
        if (Input.anyKey || Input.GetMouseButtonDown(0))
            LoadGame();
    }

}

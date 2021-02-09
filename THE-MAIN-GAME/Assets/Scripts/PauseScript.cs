using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public GameObject PausePan;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePan.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    
    public void OnClickExit()
    {
        PausePan.SetActive(false);
        Time.timeScale = 1f;
    }
}

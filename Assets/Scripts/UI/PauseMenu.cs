using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void OnResume()
    {
        Time.timeScale = 1;

        gameObject.SetActive(false);
    }
}

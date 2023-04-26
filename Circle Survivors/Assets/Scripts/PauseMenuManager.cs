using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public TimeScaleManager timeScaleManager;
    // Start is called before the first frame update
    void Start()
    {
        timeScaleManager = new TimeScaleManager();
    }


    public void Pause()
    {
        gameObject.SetActive(true);
        timeScaleManager.pauseTime();
    }

    public void Close()
	{
        timeScaleManager.unPauseTime();
        gameObject.SetActive(false);
	}
}

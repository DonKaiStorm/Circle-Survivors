using UnityEngine;

public class TimeScaleManager : MonoBehaviour
{
	public void pauseTime()
	{
		Time.timeScale = 0f;
	}

	public void unPauseTime()
	{
		Time.timeScale = 1f;
	}
}

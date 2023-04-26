using UnityEngine;
using System.Collections.Generic;

public class UpgradeUIManager : MonoBehaviour
{
    [SerializeField] GameObject upgradeUiPanel;
	TimeScaleManager timeScaleManager;

	[SerializeField] List<UpgradeButton> upgradeButtons;
	public PlayerLevel playerLevel;


	private void Awake()
	{
		timeScaleManager = GetComponent<TimeScaleManager>();
	}

	private void Start()
	{
		hideButtons();
	}
	public void openUI(List<UpgradeData> upgradeDataList)
	{
		CleanOldIcons();

		upgradeUiPanel.SetActive(true);
		timeScaleManager.pauseTime();

		for (int i = 0; i < upgradeDataList.Count; i++)
		{
			upgradeButtons[i].gameObject.SetActive(true);
			upgradeButtons[i].Set(upgradeDataList[i]);
		}
	}

	public void Upgrade(int pressedButtonID)
	{
		playerLevel.Upgrade(pressedButtonID);
		closeUI();
	}

	public void CleanOldIcons()
	{
		for (int i = 0; i < upgradeButtons.Count; i++)
		{
			upgradeButtons[i].Clean();
		}
	}

	public void closeUI()
	{
		hideButtons();

		upgradeUiPanel.SetActive(false);
		timeScaleManager.unPauseTime();
	}

	private void hideButtons()
	{
		for (int i = 0; i < upgradeButtons.Count; i++)
		{
			upgradeButtons[i].gameObject.SetActive(false);
		}
	}
}

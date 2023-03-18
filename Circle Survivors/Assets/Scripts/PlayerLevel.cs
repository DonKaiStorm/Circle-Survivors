using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int level = 1;
    public int experience = 0;
	public XPBar xpBar;

    public int TO_LEVEL_UP
	{
		get
		{
			return level * 100;
		}
	}

	public void Start()
	{
		xpBar.UpdateXP();
		xpBar.setLevelText();
	}

	public void addExperience(int amount)
	{
        experience += amount;
        checkLevelUp();
		xpBar.UpdateXP();
		
	}

    public void checkLevelUp()
	{
		if (experience >= TO_LEVEL_UP)
		{
			experience -= TO_LEVEL_UP;
			level += 1;
			xpBar.setLevelText();
		}
	}
}

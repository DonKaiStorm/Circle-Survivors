using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public PlayerLevel player;
    public Slider xpBar;
    [SerializeField] TMPro.TextMeshProUGUI levelText;

    // Update is called once per frame
    public void UpdateXP()
    {
        xpBar.value = (float) player.experience / player.TO_LEVEL_UP;
    }

    public void setLevelText()
	{
        levelText.text = "Level: " + player.level.ToString();
	}
}

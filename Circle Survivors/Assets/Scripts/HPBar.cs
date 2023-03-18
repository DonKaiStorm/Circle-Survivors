using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Character player;
    public Image hpBar;

    // Update is called once per frame
    public void UpdateHP()
    {
        hpBar.fillAmount = (float)player.currentHP / player.maxHP;
    }
}

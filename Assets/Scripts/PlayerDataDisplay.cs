using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDataDisplay : MonoBehaviour
{
    public PlayerData playerData;

    public TMP_Text nameText;
    public TMP_Text levelText;
    public TMP_Text healthText;
    public TMP_Text statusText;
    public Slider healthSlider;

    void Start()
    {
        ShowData();
    }

    void ShowData()
    {
        nameText.text = "Name: " + playerData.Name;

        
        levelText.text = "Level: " + playerData.level;

        
        healthSlider.minValue = 0;
        healthSlider.maxValue = 100;
        healthSlider.value = playerData.health;
        healthText.text = "Health: " + playerData.health;

        
        if (playerData.isAlive == true)
        {
            statusText.text = "Status: Alive";
            statusText.color = Color.green;
        }
        else
        {
            statusText.text = "Status: Dead";
            statusText.color = Color.red;
        }
    }
}
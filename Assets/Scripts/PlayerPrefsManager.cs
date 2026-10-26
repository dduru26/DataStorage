using UnityEngine;
using TMPro;

public class PlayerPrefsManager : MonoBehaviour
{

    public TMP_InputField nameInput;
    public TMP_Text nameText;
    public TMP_Text scoreText;
    public TMP_Text timeText;
    public TMP_Text messageText;

    int score;          // int
    float playTime;     // float
    string playerName;  // string

    
    float saveTimer = 0f;

    void Start()
    {
        
        LoadData();
    }

    void Update()
    {
        
        playTime = playTime + Time.deltaTime;
        timeText.text = "Play Time: " + playTime.ToString("F1") + "s";

        
        saveTimer = saveTimer + Time.deltaTime;
        if (saveTimer >= 5f)
        {
            SaveData();
            saveTimer = 0f;
        }
    }

    
    public void AddScore()
    {
        score = score + 1;
        UpdateUI();
    }

    
    public void SaveName()
    {
        playerName = nameInput.text;
        SaveData();
        UpdateUI();
    }

    
    public void SaveData()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetFloat("PlayTime", playTime);
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();

        messageText.text = "Data saved!";
        Debug.Log("Saved - Name: " + playerName + " Score: " + score + " Time: " + playTime);
    }

    
    public void LoadData()
    {
        
        score = PlayerPrefs.GetInt("Score", 0);
        playTime = PlayerPrefs.GetFloat("PlayTime", 0f);
        playerName = PlayerPrefs.GetString("PlayerName", "Guest");

        UpdateUI();
        messageText.text = "Data loaded!";
        Debug.Log("Loaded - Name: " + playerName + " Score: " + score + " Time: " + playTime);
    }

    
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        score = 0;
        playTime = 0f;
        playerName = "Guest";

        UpdateUI();
        messageText.text = "Data reset!";
    }

    void UpdateUI()
    {
        nameText.text = "Name: " + playerName;
        scoreText.text = "Score: " + score;
    }

    // save game
    void OnApplicationQuit()
    {
        SaveData();
    }
}
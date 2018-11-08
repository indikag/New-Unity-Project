using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalVariables : MonoBehaviour {

    public static string playerName = "";
    public static int score = 0;
    public static int power = 1;

    public Text nameField;
    public Text scoreField;
    public Text powerField;

    //Sets power
    public GlobalVariables(Text powerField) {
        this.powerField = powerField;
    }

    public GlobalVariables(Text powerField, Text scoreField, Text nameField)
    {
        this.powerField = powerField;
        this.scoreField = scoreField;
        this.nameField = nameField;
    }

    //Sets name and score
    public GlobalVariables(Text nameField, Text scoreField)
    {
        this.nameField = nameField;
        this.scoreField = scoreField;
    }

    //Default constructor
    public GlobalVariables()
    {}

    // Use this for initialization
    void Start () {
        this.scoreField.text = score + "";
        this.powerField.text = "POWER " + power + "%";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setPlayerName(string label)
    {
        playerName = playerName + label;
        nameField.text = playerName;
        print("player name " + playerName);
        PlayerPrefs.SetString("player_name", playerName);
    }

    public void onCancel() {
        SceneManager.LoadScene("Menu 3D");
    }

    public void onOk()
    {
        SceneManager.LoadScene("level_01");
    }

    public void nextLevel()
    {
        SceneManager.LoadScene("level_02");
    }

    public void updateScore() {
        scoreField.text = score + "";
    }

    public void addPower() {
        if (this.powerField.text == null) {
            print("power field is null");
        }
        if (power < 100) {
            power = power + 1;
            print(power);
            this.powerField.text = "POWER " + power + "%";
        } else {
            power = 100;
            this.powerField.text = "POWER 100%";
        }
    }

    public void reducePower()
    {
        if (power > 0) {
            power = power - 1;
            this.powerField.text = "POWER " + power + "%";
        } else {
            power = 0;
            this.powerField.text = "POWER 0%";
        }
    }

    public void addPoint() {
        int newScore = 0;
        newScore = score + 5;
        
        this.scoreField.text = newScore.ToString();
    }

    public void reducePoint()
    {
        int newScore = 0;
        if (score <= 0) {
            newScore = 0;
        } else {
            newScore = score - 1;
        }

        this.scoreField.text = newScore.ToString();
    }
}

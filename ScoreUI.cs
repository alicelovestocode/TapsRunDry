using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    private Text waterSusText;
    private Text enviroText;
    private Text economyText;
    private Text societyText;
    private Text scoreText;
    private Text endText;
    private List<Text> textList;

    void Start()
    {
        textList = new List<Text>();
        textList.Add(waterSusText = GameObject.Find("Canvas/WaterSusText").GetComponent<Text>());
        textList.Add(enviroText = GameObject.Find("Canvas/EnviroText").GetComponent<Text>());
        textList.Add(economyText = GameObject.Find("Canvas/EconomyText").GetComponent<Text>());
        textList.Add(societyText = GameObject.Find("Canvas/SocietyText").GetComponent<Text>());
        textList.Add(scoreText = GameObject.Find("Canvas/FinalScoreText").GetComponent<Text>());
        textList.Add(endText = GameObject.Find("Canvas/EndDialogueText").GetComponent<Text>());
    }

    public void UpdateScore()
    {
        foreach (Text text in textList) { text.GetComponent<Text>().enabled = true; }

        waterSusText.text = string.Format("Water Sustainability Score:  {0}", GM.GetData.WaterSustainability);
        enviroText.text = string.Format("Environment Score:             {0}", GM.GetData.Environment);
        economyText.text = string.Format("Economy Score:                  {0}", GM.GetData.Economy);
        societyText.text = string.Format("Society Score:                     {0}", GM.GetData.Society);
        scoreText.text = string.Format("Final Score:                         {0}", GM.GetData.FinalScore);
    }

    public void UpdateDialogue(string randomEnd) { endText.text = string.Format(randomEnd); }
}

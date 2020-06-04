using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour 
{
    Data data;
    private GameObject UIM;
    private GameObject canvas;
    private GameObject scoreCard;
    private GameObject playBtn;
    private GameObject quitBtn;
    private GameObject yesBtn;
    private GameObject noBtn;
    private GameObject[] npcArr;
    private GameObject[] envBgArr;
    private List<GameObject> npcList;
    private List<GameObject> envBgList;
    private GameObject goodBg;
    private GameObject neutralBg;
    private GameObject badBg;
    private bool gameEnd;

    static GM mSingleton = null;

    public static GM singleton { get { return mSingleton; } }

    public static Data GetData { get { return singleton.data; } }

    void Awake() 
    {
        if (mSingleton == null)
        {
            mSingleton = this;
            data = new Data();
            DontDestroyOnLoad(gameObject);
            gameObject.tag = "GM";
        }
        if (mSingleton != this) { Destroy(gameObject); }
    }

    void Start()
    {
        data.LoadFiles();

        UIM = GameObject.FindGameObjectWithTag("UI");
        scoreCard = GameObject.FindGameObjectWithTag("SCORE");
        playBtn = GameObject.FindGameObjectWithTag("PLAY");
        quitBtn = GameObject.FindGameObjectWithTag("QUIT");
        yesBtn = GameObject.FindGameObjectWithTag("YES");
        noBtn = GameObject.FindGameObjectWithTag("NO");
        canvas = GameObject.FindGameObjectWithTag("CANVAS");
        npcArr = GameObject.FindGameObjectsWithTag("NPC");
        envBgArr = GameObject.FindGameObjectsWithTag("BG");

        data.WaterSustainability = 5;
        data.Environment = 5;
        data.Economy = 5;
        data.Society = 5;
        data.FinalScore = 0;

        foreach (GameObject npc in npcArr) { npc.GetComponent<Renderer>().enabled = false; }
        Shuffle(npcArr);
        npcList = new List<GameObject>(npcArr);
        foreach (GameObject bg in envBgArr) { bg.GetComponent<Renderer>().enabled = false; }
        envBgList = new List<GameObject>(envBgArr);

        goodBg = envBgList.Find(x => x.name == "EnvironmentBackgroundGood");
        neutralBg = envBgList.Find(x => x.name == "EnvironmentBackgroundNeutral");
        badBg = envBgList.Find(x => x.name == "EnvironmentBackgroundBad");

        neutralBg.GetComponent<Renderer>().enabled = true;
        scoreCard.GetComponent<Renderer>().enabled = false;
        playBtn.SetActive(false);
        quitBtn.SetActive(false);

        Summon();
    }

    private void Shuffle(GameObject[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            GameObject tmp = arr[i];
            int r = UnityEngine.Random.Range(i, arr.Length);
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }

    private void Summon()
    {
        if (npcList.Count == 0) 
        {
            gameEnd = true;
            CalculateScore();
        }
        else { npcList[0].GetComponent<Renderer>().enabled = true; }
    }

    public void Approve()
    {
        npcList[0].GetComponent<Renderer>().enabled = false;

        switch (npcList[0].name)
        {
            case "MotherNature":
                data.WaterSustainability += 0.75;
                data.Environment += 0.75;
                break;
            case "Zeke":
                data.WaterSustainability -= 0.5;
                data.Environment -= 0.75;
                data.Economy += 0.25;
                data.Society += 0.75;
                break;
            case "Layla":
                data.WaterSustainability += 0.25;
                data.Environment += 0.25;
                data.Economy -= 0.75;
                data.Society -= 0.5;
                break;
            case "Hugo":
                data.WaterSustainability += 0.75;
                data.Society += 0.5;
                break;
            case "Heinrich":
                data.WaterSustainability -= 0.75;
                data.Environment -= 0.75;
                data.Economy += 0.75;
                data.Society += 0.5;
                break;
            case "Eduardo":
                data.WaterSustainability -= 0.75;
                data.Society += 0.25;
                break;
            case "Darren":
                data.WaterSustainability += 0.75;
                data.Environment += 0.75;
                data.Economy -= 0.5;
                break;
            case "Damon":
                data.WaterSustainability -= 0.75;
                data.Environment -= 0.75;
                data.Economy += 0.75;
                data.Society += 0.25;
                break;
            case "Cordelia":
                data.WaterSustainability += 0.75;
                data.Environment += 0.5;
                data.Society += 0.5;
                break;
            case "Adam":
                data.WaterSustainability += 0.75;
                data.Economy -= 0.25;
                data.Society += 0.5;
                break;
            default:
                Debug.LogError("Error: A fatal error has occured in Approve().");
                break;
        }

        CalculateScore();
        npcList.RemoveAt(0);
        Summon();
    }

    public void Decline()
    {
        npcList[0].GetComponent<Renderer>().enabled = false;

        switch (npcList[0].name)
        {
            case "MotherNature":
                data.WaterSustainability -= 0.5;
                data.Environment -= 0.5;
                break;
            case "Zeke":
                data.WaterSustainability += 0.5;
                data.Environment += 0.5;
                data.Economy = -0.5;
                data.Society -= 0.75;
                break;
            case "Layla":
                data.WaterSustainability -= 0.75;
                data.Environment -= 0.75;
                data.Economy += 0.75;
                data.Society += 0.25;
                break;
            case "Hugo":
                data.WaterSustainability -= 0.25;
                data.Society -= 0.25;
                break;
            case "Heinrich":
                data.Economy -= 0.5;
                data.Society -= 0.25;
                break;
            case "Eduardo":
                data.Society -= 0.25;
                break;
            case "Darren":
                data.WaterSustainability -= 0.25;
                data.Environment -= 0.25;
                data.Economy += 0.5;
                break;
            case "Damon":
                data.WaterSustainability += 0.75;
                data.Environment += 0.75;
                data.Economy -= 0.75;
                break;
            case "Cordelia":
                data.WaterSustainability += 0.25;
                data.Environment += 0.5;
                data.Society -= 0.25;
                break;
            case "Adam":
                data.WaterSustainability -= 0.5;
                data.Society -= 0.25;
                break;
            default:
                Debug.LogError("Error: A fatal error has occured in Decline().");
                break;
        }

        CalculateScore();
        npcList.RemoveAt(0);
        Summon();
    }

    private void EndGame(List<string> endList)
    {
        scoreCard.GetComponent<Renderer>().enabled = true;
        playBtn.SetActive(true);
        quitBtn.SetActive(true);
        yesBtn.SetActive(false);
        noBtn.SetActive(false);
        
        var random = new System.Random();
        int index = random.Next(endList.Count);

        canvas.GetComponent<ScoreUI>().UpdateScore();
        canvas.GetComponent<ScoreUI>().UpdateDialogue(endList[index]);
    }

    private void CalculateScore()
    {
        data.FinalScore = Math.Round(((data.WaterSustainability + data.Environment + data.Economy + data.Society) / 4), 2);

        if (data.FinalScore <= 5)
        {
            goodBg.GetComponent<Renderer>().enabled = false;
            neutralBg.GetComponent<Renderer>().enabled = false;
            badBg.GetComponent<Renderer>().enabled = true;

            if (gameEnd) { EndGame(data.EndListBad); }
        }
        else if (data.FinalScore > 5 && data.FinalScore < 6)
        {
            goodBg.GetComponent<Renderer>().enabled = false;
            neutralBg.GetComponent<Renderer>().enabled = true;
            badBg.GetComponent<Renderer>().enabled = false;

            if (gameEnd) { EndGame(data.EndListNeutral); }
        }
        else if (data.FinalScore >= 6)
        {
            goodBg.GetComponent<Renderer>().enabled = true;
            neutralBg.GetComponent<Renderer>().enabled = false;
            badBg.GetComponent<Renderer>().enabled = false;

            if (gameEnd) { EndGame(data.EndListGood); }
        }
    }
}

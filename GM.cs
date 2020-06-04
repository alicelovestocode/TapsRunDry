using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour 
{

    Data data;
    public GameObject UIM;
    public GameObject[] npcArr;
    public GameObject[] envBgArr;
    public List<GameObject> npcList;
    public List<GameObject> envBgList;
    private GameObject goodBg;
    private GameObject neutralBg;
    private GameObject badBg;

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
        npcArr = GameObject.FindGameObjectsWithTag("NPC");
        envBgArr = GameObject.FindGameObjectsWithTag("BG");

        data.WaterSustainability = 5;
        data.Environment = 5;
        data.Economy = 5;
        data.Society = 5;

        foreach (GameObject npc in npcArr) { npc.GetComponent<Renderer>().enabled = false; }
        Shuffle(npcArr);
        npcList = new List<GameObject>(npcArr);
        foreach (GameObject bg in envBgArr) { bg.GetComponent<Renderer>().enabled = false; }
        envBgList = new List<GameObject>(envBgArr);

        goodBg = envBgList.Find(x => x.name == "EnvironmentBackgroundGood");
        neutralBg = envBgList.Find(x => x.name == "EnvironmentBackgroundNeutral");
        badBg = envBgList.Find(x => x.name == "EnvironmentBackgroundBad");

        neutralBg.GetComponent<Renderer>().enabled = true;
        Summon();
    }

    void Shuffle(GameObject[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            GameObject tmp = arr[i];
            int r = Random.Range(i, arr.Length);
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }

    void Summon()
    {
        if (npcList.Count == 0) 
        { 
            UIM.GetComponent<UIManager>().ChangeScene();
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

        Debug.Log("water sustainability: " + data.WaterSustainability);
        Debug.Log("environmental: " + data.Environment);
        Debug.Log("economical: " + data.Economy);
        Debug.Log("social: " + data.Society);

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

        Debug.Log("water sustainability: " + data.WaterSustainability);
        Debug.Log("environmental: " + data.Environment);
        Debug.Log("economical: " + data.Economy);
        Debug.Log("social: " + data.Society);

        CalculateScore();
        npcList.RemoveAt(0);
        Summon();
    }

    void CalculateScore()
    {
        double totalScore = data.WaterSustainability + data.Environment + data.Economy + data.Society;
        double meanAverage = totalScore / 4;
        Debug.Log("your average score: " + meanAverage);

        if (meanAverage <= 5)
        {
            Debug.Log("background to show: " + badBg.name);
            goodBg.GetComponent<Renderer>().enabled = false;
            neutralBg.GetComponent<Renderer>().enabled = false;
            badBg.GetComponent<Renderer>().enabled = true;

            /*if (npcList.Count == 0)
            {
                // show end scenario and score
            }*/
        }
        else if (meanAverage > 5 && meanAverage < 6)
        {
            Debug.Log("background to show: " + neutralBg.name);
            goodBg.GetComponent<Renderer>().enabled = false;
            neutralBg.GetComponent<Renderer>().enabled = true;
            badBg.GetComponent<Renderer>().enabled = false;

            /*if (npcList.Count == 0)
            {
                // show end scenario and score
            }*/
        }
        else if (meanAverage >= 6)
        {
            Debug.Log("background to show: " + goodBg.name);
            goodBg.GetComponent<Renderer>().enabled = true;
            neutralBg.GetComponent<Renderer>().enabled = false;
            badBg.GetComponent<Renderer>().enabled = false;

            /*if (npcList.Count == 0)
            {
                // show end scenario and score
            }*/
        }
    }
}

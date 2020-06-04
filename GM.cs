using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour 
{

    Data data;
    public GameObject uim;
    public GameObject[] npcArr;
    public List<GameObject> npcList;

    static GM mSingleton = null;

    public static GM singleton 
    {
        get  
        {
            return mSingleton;
        }
    }

    public static Data GetData 
    {
        get  
        {
            return singleton.data;
        }
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

    void Awake() 
    {
        if (mSingleton == null)
        {
            mSingleton = this;
            data = new Data();
            DontDestroyOnLoad(gameObject);
        }
        if (mSingleton != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        data.LoadFiles();

        uim = GameObject.FindGameObjectWithTag("UI");
        npcArr = GameObject.FindGameObjectsWithTag("NPC");

        data.WaterSustainability = 5;
        data.Environment = 5;
        data.Economy = 5;
        data.Society = 5;

        foreach (GameObject npc in npcArr)
        {
            npc.GetComponent<Renderer>().enabled = false;
        }
        Shuffle(npcArr);
        npcList = new List<GameObject>(npcArr);
        Summon();
    }

    void Summon()
    {
        if (npcList.Count == 0)
        {
            uim.GetComponent<UIManager>().ChangeScene();
        }
        else
        {
            npcList[0].GetComponent<Renderer>().enabled = true;
        }
    }

    public void Approve()
    {
        npcList[0].GetComponent<Renderer>().enabled = false;
        npcList.RemoveAt(0);

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

        Summon();
    }

    public void Decline()
    {
        npcList[0].GetComponent<Renderer>().enabled = false;
        npcList.RemoveAt(0);

        switch (npcList[0].name)
        {
            case "MotherNature":
                data.WaterSustainability -= 0.5;
                data.Environment -= 0.5;
                break;
            case "Zeke":
                data.WaterSustainability += 0.5;
                data.Environemnt += 0.5;
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

        Summon();
    }
}

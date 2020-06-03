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
        uim = GameObject.FindGameObjectWithTag("UI");
        npcArr = GameObject.FindGameObjectsWithTag("NPC");

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
        data.LoadFile();
        npcList[0].GetComponent<Renderer>().enabled = false;
        npcList.RemoveAt(0);

        switch (npcList[0].name)
        {
            case "MotherNature":
                Debug.Log("mothernature here");
                break;
            case "Zeke":
                Debug.Log("zeke here");
                break;
            case "Layla":
                Debug.Log("layla here");
                break;
            case "Hugo":
                Debug.Log("hugo here");
                break;
            case "Heinrich":
                Debug.Log("heinrich here");
                break;
            case "Eduardo":
                Debug.Log("eduardo here");
                break;
            case "Darren":
                Debug.Log("darren here");
                break;
            case "Damon":
                Debug.Log("dmaon here");
                break;
            case "Cordelia":
                Debug.Log("cordelia here");
                break;
            case "Adam":
                Debug.Log("adam here");
                break;
            default:
                Debug.LogError("Error: A fatal error has occured in Approve().");
                break;
        }

        data.WaterSustainability += 1;
        Debug.Log("water sustainability: " + data.WaterSustainability);
        Summon();
    }

    public void Decline()
    {
        npcList[0].GetComponent<Renderer>().enabled = false;
        npcList.RemoveAt(0);
        Summon();
    }
}

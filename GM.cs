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
        npcList[0].GetComponent<Renderer>().enabled = false;
        npcList.RemoveAt(0);
        Summon();
    }

    public void Decline()
    {
        npcList[0].GetComponent<Renderer>().enabled = false;
        npcList.RemoveAt(0);
        Summon();
    }
}

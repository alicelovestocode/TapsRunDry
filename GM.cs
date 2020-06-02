using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GM : MonoBehaviour 
{

    Data data;
    public GameObject uim;
    public GameObject[] npcArr;

    static GM mSingleton = null;

    public static GM singleton 
    {
        get  {
            return mSingleton;
        }
    }

    public static Data GetData 
    {
        get  {
            return singleton.data;
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

    void Update()
    {
        // this is a temporary measure until logic has been coded into the game
        if (Input.GetKeyDown(KeyCode.W))
        {
            uim = GameObject.FindGameObjectWithTag("UI");
            //uim.GetComponent<UIManager>().ChangeScene();

            npcArr = GameObject.FindGameObjectsWithTag("NPC");
            Debug.Log("npc array: " + npcArr.ToString());
            Debug.Log("npc array size: " + npcArr.Length);

            foreach (GameObject npc in npcArr)
            {
                npc.SetActive(false);
            }

            Debug.Log("npc array: " + npcArr.ToString());
            Debug.Log("npc array size: " + npcArr.Length);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour 
{

    Data data;
    public GameObject uim;

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
            uim.GetComponent<UIManager>().ChangeScene();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Data 
{
    public List<string> endListGood;
    public List<string> endListBad;

    public void LoadFile()
    {
        try
        {
            string[] lines1 = System.IO.File.ReadAllLines(@"Assets\Text\endtext1.txt");
            endListBad = new List<string>(lines1);
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError(String.Format("Error: The file was not found: '{0}'", e));
        }
        catch (IOException e)
        {
            Debug.LogError(String.Format("Error: The file could not be opened: '{0}'", e));
        }

        try
        {
            string[] lines2 = System.IO.File.ReadAllLines(@"Assets\Text\endtext2.txt");
            endListGood = new List<string>(lines2);
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError(String.Format("Error: The file was not found: '{0}'", e));
        }
        catch (IOException e)
        {
            Debug.LogError(String.Format("Error: The file could not be opened: '{0}'", e));
        }
    }

    private int mWaterSustainability;
    public int WaterSustainability
    {
        get 
        {
            return mWaterSustainability;
        }
        set 
        {
            if (value >= 0)
            {
                mWaterSustainability = value;
            }
        }
    }

    private int mEnvironment;
    public int Environment
    {
        get 
        {
            return mEnvironment;
        }
        set 
        {
            if (value >= 0)
            {
                mEnvironment = value;
            }
        }
    }

    private int mEconomy;
    public int Economy
    {
        get 
        {
            return mEconomy;
        }
        set 
        {
            if (value >= 0)
            {
                mEconomy = value;
            }
        }
    }

    private int mSociety;
    public int Society
    {
        get 
        {
            return mSociety;
        }
        set 
        {
            if (value >= 0)
            {
                mSociety = value;
            }
        }
    }


}

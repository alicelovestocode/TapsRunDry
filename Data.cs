using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Data 
{
    private double mWaterSustainability;
    public double WaterSustainability
    {
        get { return mWaterSustainability;}
        set { if (value >= 0) { mWaterSustainability = value; } }
    }

    private double mEnvironment;
    public double Environment
    {
        get { return mEnvironment; }
        set { if (value >= 0) { mEnvironment = value; } }
    }

    private double mEconomy;
    public double Economy
    {
        get { return mEconomy; }
        set { if (value >= 0) { mEconomy = value; } }
    }

    private double mSociety;
    public double Society
    {
        get { return mSociety; }
        set { if (value >= 0) { mSociety = value; } }
    }

    private double mFinalScore;
    public double FinalScore
    {
        get { return mFinalScore; }
        set { if (value >= 0) { mFinalScore = value; } }
    }

    public List<string> EndListGood;
    public List<string> EndListBad;
    public List<string> EndListNeutral;

    public void LoadFiles()
    {
        try
        {
            string[] lines1 = System.IO.File.ReadAllLines(@"Assets\Text\endtext1.txt");
            EndListBad = new List<string>(lines1);
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
            EndListGood = new List<string>(lines2);
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
            string[] lines3 = System.IO.File.ReadAllLines(@"Assets\Text\endtext3.txt");
            EndListNeutral = new List<string>(lines3);
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
}

using System.Collections;
using System.Collections.Generic;

public class Data 
{
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

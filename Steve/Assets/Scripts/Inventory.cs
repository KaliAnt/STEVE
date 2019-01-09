using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private uint currency;
    private uint[] eyes;
    private float speed;
    private uint fetchers;

    public Inventory(uint currency, uint[] eyes, float speed, uint fetchers)
    {
        this.currency = currency;
        this.eyes = eyes;
        this.speed = speed;
        this.fetchers = fetchers;
    }

    public void AddCurrencyAmount(uint amount)
    {
        currency += amount;
    }

    public bool SubstractCurrencyAmount(uint amount)
    {
        if (amount < currency)
        {
            currency -= currency;
            return true;
        }
        return false;
    }

    public bool UpgradeEye(uint index)
    {
        if (index < 5)
        {
            if (eyes[index] > 0)
                eyes[index]++;
        }
        return false;
    }

    public bool UpgradeSpeed(float size)
    {
        if (size > 0)
        {
            speed += size;
            return true;
        }
        return false;
    }

    public void UpgradeFetchers(uint amount)
    {
        fetchers += amount;
    }

    public uint GetEye(uint index)
    {
        if (index < 5)
            return eyes[index];
        return 0;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public uint GetFetchers()
    {
        return fetchers;
    }


}

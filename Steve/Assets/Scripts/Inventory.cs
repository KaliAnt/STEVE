using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private int currency;
    private int eyes;
    private int speed;
    private int fetchers;

    public Inventory(int currency, int eyes, int speed, int fetchers)
    {
        this.currency = currency;
        this.eyes = eyes;
        this.speed = speed;
        this.fetchers = fetchers;
    }

    public bool AddCurrencyAmount(int amount)
    {
        if (amount > 0)
        {
            currency += amount;
            return true;
        }
        return false;
    }

    public bool SubstractCurrencyAmount(int amount)
    {
        if (amount > 0 && amount < currency)
        {
            currency -= currency;
            return true;
        }
        return false;
    }

    public bool upgradeEye(int eyeNumber)
    {
        return false;
    }
}

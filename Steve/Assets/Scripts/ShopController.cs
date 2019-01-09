﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public uint eyePrice;
    public uint visionPrice;
    public uint speedPrice;

    private Inventory inventory;
    private PlayerController playerController;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        if (playerController)
            inventory = playerController.GetInventory();
    }

    public bool BuyEye(uint index)
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (player)
        {
            Inventory playerInventory = playerController.GetInventory();

            if (playerInventory.SubstractCurrencyAmount(eyePrice))
            {
                playerInventory.UpgradeEye(index);
                return true;
            }
        }
        return false;
    }

    public bool IsActiveEye(uint index)
    {
        Inventory inv = playerController.GetInventory();
        return inv.GetEye(index) == 1 ? true : false;
    }
}
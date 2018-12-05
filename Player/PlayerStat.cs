using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat {

    public float moveSpeed;
    public float maxHP;
    public float currentHP;
    public int atkPower;

    public PlayerStat()
    {
        moveSpeed = 8.0f;
        maxHP = 20;
        currentHP = maxHP;
        atkPower = 2;
    }

}

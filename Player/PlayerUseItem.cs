using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseItem : MonoBehaviour {

    Player player;
    Enemy enemy;
    ActionLog action;
	// Use this for initialization
	void Start () {

        player = Player.instance;
        enemy = Enemy.instance;
        action = ActionLog.instance;
	}

    public bool UseItem(Item item)
    {
        if (item.isFreeze)
        {
            Debug.Log("Use freeze item");

            if(enemy.GetFrozen(item.freezeTime))
            {
                GameRecord.usedIceStone = true;
                return true;
            }

            return false;
            
        }
        else if (item.isHP)
        {
            Debug.Log("Recover HP");
            player.RecoverHP(item.recoverHP);
            GameRecord.usedApple = true;
            AudioManager.Play("EatApple");
            return true;
        }
        else if (item.isSpeedUp)
        {
            Debug.Log("Speed up");
            player.SpeedUp(item.newSpeedTime, item.newSpeed);
            GameRecord.usedSpeedUp = true;
            AudioManager.Play("SpeedUp");
            return true;
        }
        else if(item.isWeapon)
        {
            if(enemy.ReceiveDamage(item.damage))
            {
                return true;
            }

            return false;

        }else
        {
            action.NewLog("Nothing happens");
            return false;
        }
    }
}

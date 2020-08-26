using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseSong : MonoBehaviour
{
    public GameManager gM;

    public void CalculateSongSuccess(Song theSong) {
        float successNum = ((theSong.catchy * 2) + theSong.unique + theSong.polish) * theSong.hype / 2;

        theSong.chartNum = Mathf.RoundToInt(500 - successNum);
        theSong.chartNum = Mathf.Clamp(theSong.chartNum, 1, 500);

        if (theSong.chartNum > 100)
        {
            theSong.moneyEarned = successNum * 3f;
        }
        else if (theSong.chartNum > 10)
        {
            theSong.moneyEarned = successNum * 7f;

        }
        else if (theSong.chartNum > 2)
        {
            theSong.moneyEarned = successNum * 20f;

        }
        else {
            theSong.moneyEarned = successNum * 40f;
        }
        

        

        gM.totalMoney += theSong.moneyEarned;

        Debug.Log(successNum);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseSong : MonoBehaviour
{
    public GameManager gM;

    public void CalculateSongSuccess(Song theSong) {
        float successNum = (theSong.catchy + theSong.unique + theSong.polish) * theSong.hype;

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
        else {
            theSong.moneyEarned = successNum * 20f;

        }
        

        

        gM.totalMoney += theSong.moneyEarned;

        Debug.Log(successNum);
        
    }
}

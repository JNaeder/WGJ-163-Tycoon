using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marketing : MonoBehaviour
{
    public SongManagment sM;
    public GameManager gM;

    public float radioAmount, tvAmount, socialMediaAmount, totalAmount, totalHype;
    public Text radioAmountTxt, tvAmountTxt, socialMediaAmountTxt, totalAmountTxt, totalHypeTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalAmount = radioAmount + tvAmount + socialMediaAmount;
        CalculateHype();

        radioAmountTxt.text = "$" + radioAmount.ToString("F2");
        tvAmountTxt.text = "$" + tvAmount.ToString("F2");
        socialMediaAmountTxt.text = "$" + socialMediaAmount.ToString("F2");
        totalAmountTxt.text = "$" + totalAmount.ToString("F2");
        totalHypeTxt.text = totalHype.ToString("F1");
    }

    public void CalculateHype()
    {
        totalHype = Mathf.RoundToInt(radioAmount / 1000) + Mathf.RoundToInt(tvAmount / 1000) + Mathf.RoundToInt(socialMediaAmount / 1000);


    }


    public void SetRadioAmount(float value) {
        radioAmount = value;

    }

    public void SetTVAmount(float value) {
        tvAmount = value;
    }

    public void SetSocialMediaAmount(float value) {
        socialMediaAmount = value;

    }


    public void PurchaseMarketing() {
        sM.selectedSong.hype += totalHype;
        gM.totalMoney -= totalAmount;

        sM.ClosePopUpWindow();
        sM.ShowSongDetails(sM.selectedSong);

    }
}

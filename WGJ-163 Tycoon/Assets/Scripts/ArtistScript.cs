using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtistScript : MonoBehaviour
{
    public Artist theArtist;

    public Text artistName;
    public Text artistage;
    public Text artistStyle;
    public Text artistTalent;

    GameManager gM;

    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();


    }

    // Update is called once per frame
    void LateUpdate()
    {
        artistName.text = theArtist.artistName;
        artistage.text = theArtist.artistAge.ToString();
        artistStyle.text = theArtist.styleStat.ToString("F1");
        artistTalent.text = theArtist.talentStat.ToString("F1");
    }


    public void ChooseCard() {
        gM.SignArtist(theArtist);

    }
}

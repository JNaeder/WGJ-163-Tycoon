﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtistScript : MonoBehaviour
{
    public Artist theArtist;

    public Text artistName;
    public Text artistage;
    public Text artistGenre;
    public Image artistImage;
    public Image artistTalent;
    public Image artistStyle;

    GameManager gM;
    FindArtistScreen fAS;

    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();
        fAS = FindObjectOfType<FindArtistScreen>();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        artistName.text = theArtist.artistName;
        artistage.text = theArtist.artistAge.ToString();
        artistGenre.text = theArtist.genre;
        artistImage.sprite = theArtist.artistImage;
        SetPercBars();
    }

    void SetPercBars() {
        float talentPerc = theArtist.talentStat / 10;
        float stylePerc = theArtist.styleStat / 10;
        Vector3 talentScale = artistTalent.rectTransform.localScale;
        talentScale.x = talentPerc;
        artistTalent.rectTransform.localScale = talentScale;
        Vector3 styleScale = artistStyle.rectTransform.localScale;
        styleScale.x = stylePerc;
        artistStyle.rectTransform.localScale = styleScale;


    }


    public void SelectCard() {
        fAS.selectedCard = this.gameObject;
    }

    IEnumerator WaitAndDeselect() {
        yield return new WaitForSeconds(0.1f);
        fAS.selectedCard = null;
    }

    public void DeselectCard() {
        StartCoroutine(WaitAndDeselect());
    }


}

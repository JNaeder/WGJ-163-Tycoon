using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListButton : MonoBehaviour
{
    MakeSongScreen mSS;

    public Artist buttonArtist;
    public Producer buttonProducer;
    public string buttonGenre;

    Button thisButton;



    private void Start()
    {
        thisButton = GetComponent<Button>();
        mSS = FindObjectOfType<MakeSongScreen>();
    }

    private void Update()
    {
        if (mSS.selectedArtist == buttonArtist || mSS.selectedProducer == buttonProducer || mSS.selectedGenre == buttonGenre)
        {
            thisButton.GetComponent<Image>().color = Color.green;
        }
        else {
            thisButton.GetComponent<Image>().color = Color.white;
        }
    }


    public void SelectArtist() {
        mSS.selectedArtist = buttonArtist;
    }

    public void SelectProducer() {
        mSS.selectedProducer = buttonProducer;

    }

    public void SelectGenre() {
        mSS.selectedGenre = buttonGenre;

    }
}

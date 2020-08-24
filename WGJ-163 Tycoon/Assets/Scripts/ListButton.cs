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
        if (buttonArtist != null)
        {
            if (mSS.selectedArtist == buttonArtist)
            {
                TurnButtonColor(Color.green);
            }
            else {
                TurnButtonColor(Color.white);
            }
        }
        else if (buttonProducer != null)
        {
            if (mSS.selectedProducer == buttonProducer)
            {
                TurnButtonColor(Color.green);
            }
            else {
                TurnButtonColor(Color.white);
            }

        }
        else if (buttonGenre != null) {
            if (mSS.selectedGenre == buttonGenre)
            {
                TurnButtonColor(Color.green);
            }
            else {
                TurnButtonColor(Color.white);

            }

        }
    }

    void TurnButtonColor(Color newColor) {
        thisButton.GetComponent<Image>().color = newColor;

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

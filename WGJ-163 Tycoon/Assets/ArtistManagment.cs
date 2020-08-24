using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtistManagment : MonoBehaviour
{

    public GameManager gM;

    public GameObject artistManagmentButton;

    public Transform artistList;


    public Text artistName, artistAge, artistTalent, artistStyle;

    private void OnEnable()
    {
        DeleteArtistList();
        MakeList();
    }

    public void MakeList()
    {
        foreach (Artist a in gM.listOfSignedArtists)
        {
            GameObject newButton = Instantiate(artistManagmentButton, Vector2.zero, Quaternion.identity, artistList) as GameObject;
            Text buttonText = newButton.GetComponentInChildren<Text>();
            ManagmentButton buttonManagmentButton = newButton.GetComponent<ManagmentButton>();
            buttonManagmentButton.buttonArtist = a;
            buttonText.text = a.artistName;

        }


    }

    public void DeleteArtistList()
    {
        Button[] listOfButtons = GetComponentsInChildren<Button>();

        foreach (Button b in listOfButtons)
        {
            Destroy(b.gameObject);
        }

    }


    public void ShowArtistDetails(Artist theArtist) {
        artistName.text = theArtist.artistName;
        artistAge.text = theArtist.artistAge.ToString();
        artistTalent.text = theArtist.talentStat.ToString("F2");
        artistStyle.text = theArtist.styleStat.ToString("F2");

    }
}

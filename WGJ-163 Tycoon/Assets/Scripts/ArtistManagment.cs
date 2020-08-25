using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtistManagment : MonoBehaviour
{

    public GameManager gM;

    public GameObject artistManagmentButton;
    public GameObject detailWindow;

    public Transform artistList;

    public Artist selectedArtist;




    public Text artistName, artistAge, artistTalent, artistStyle, artistGenre;
    public Image artistImage;

   

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
        Button[] listOfButtons = artistList.GetComponentsInChildren<Button>();

        foreach (Button b in listOfButtons)
        {
            Destroy(b.gameObject);
        }

    }


    public void ShowArtistDetails(Artist theArtist) {
        detailWindow.SetActive(true);
        artistName.text = theArtist.artistName;
        artistAge.text = theArtist.artistAge.ToString();
        artistTalent.text = theArtist.talentStat.ToString("F1");
        artistStyle.text = theArtist.styleStat.ToString("F1");
        artistGenre.text = theArtist.genre;
        artistImage.sprite = theArtist.artistImage;

    }


    public void SelectArtist(Artist theArtist) {
        selectedArtist = theArtist;

    }

    public void FireArtist() {
        gM.FireArtist(selectedArtist);
        selectedArtist = null;
        DeleteArtistList();
        MakeList();
        detailWindow.SetActive(false);

    }
}

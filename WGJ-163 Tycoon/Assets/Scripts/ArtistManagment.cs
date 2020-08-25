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




    public Text artistName, artistGenre;
    public Image artistImage, artistTalent, artistStyle;

    private void Update()
    {
        if (selectedArtist != null)
        {
            SetPercBars();
        }
    }

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
    void SetPercBars()
    {
        float talentPerc = selectedArtist.talentStat / 10;
        float stylePerc = selectedArtist.styleStat / 10;
        Vector3 talentScale = artistTalent.rectTransform.localScale;
        talentScale.x = talentPerc;
        artistTalent.rectTransform.localScale = talentScale;
        Vector3 styleScale = artistStyle.rectTransform.localScale;
        styleScale.x = stylePerc;
        artistStyle.rectTransform.localScale = styleScale;


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

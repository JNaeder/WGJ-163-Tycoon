using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindArtistScreen : MonoBehaviour
{
    public GameManager gM;

    public GameObject artistCard;

    public Transform cardParent;

    public TextAsset maleNamesTxt;
    string[] maleNames;

    public TextAsset femaleNamesTxt;
    string[] femaleNames;

    public Sprite[] maleImages;
    public Sprite[] femaleImages;

    public Button chooseArtistButton;

    
    public GameObject selectedCard;

    private void Start()
    {
        maleNames = maleNamesTxt.text.Split('\n');
        femaleNames = femaleNamesTxt.text.Split('\n');

    }

    private void Update()
    {
        if (selectedCard == null)
        {
            chooseArtistButton.interactable = false;
        }
        else {
            chooseArtistButton.interactable = true;
        }

    }

    public void CreateMutipleCards(int numOfCards) {
        DestroyCards();
        for (int i = 0; i < numOfCards; i++) {
            CreateArtistCards(CreateRandomArtist());

        }


    }

    public void DestroyCards()
    {
        ArtistScript[] cardsInParent = cardParent.GetComponentsInChildren<ArtistScript>();
        foreach (ArtistScript t in cardsInParent)
        {
            Destroy(t.gameObject);
        }
    }


    void CreateArtistCards(Artist thisArtist)
    {
        GameObject newArtist = ScriptableObject.Instantiate(artistCard, Vector2.zero, Quaternion.identity, cardParent) as GameObject;
        ArtistScript artistS = newArtist.GetComponent<ArtistScript>();
        artistS.theArtist = thisArtist;

    }

    Artist CreateRandomArtist() {
        Artist newArtist = ScriptableObject.CreateInstance<Artist>();
        int randGender = Random.Range(0, 2);
        if (randGender == 0)
        {
            int randNum = Random.Range(0, maleNames.Length);
            newArtist.artistName = maleNames[randNum];
            int randNumm = Random.Range(0, maleImages.Length);
            newArtist.artistImage = maleImages[randNumm];
        }
        else {
            int randNum = Random.Range(0, femaleNames.Length);
            newArtist.artistName = femaleNames[randNum];
            int randNumm = Random.Range(0, femaleImages.Length);
            newArtist.artistImage = femaleImages[randNumm];

        }

        
        newArtist.artistAge = Random.Range(18, 50);
        newArtist.styleStat = Random.Range(0.0f, 10.0f);
        newArtist.talentStat = Random.Range(0.0f, 10.0f);
        int randNum2 = Random.Range(0, gM.genresList.Length);
        newArtist.genre = gM.genresList[randNum2];

        newArtist.name = newArtist.artistName;

        return newArtist;
    }

    public void ChooseArtist() {
        Artist newArtist = selectedCard.GetComponent<ArtistScript>().theArtist;
        gM.SignArtist(newArtist);
        Destroy(selectedCard);

    }

    
}

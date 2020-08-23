using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindArtistScreen : MonoBehaviour
{

    public Artist[] listOfArtists;

    public GameObject artistCard;

    public Transform cardParent;

    string[] maleNames;

    private void Start()
    {
        maleNames = System.IO.File.ReadAllLines("/Volumes/Macintosh HD/Github/WGJ-163 Tycoon/Assets/MaleName.txt");

    }

    public void CreateMutipleCards(int numOfCards) {
        DestroyCards();
        for (int i = 0; i < numOfCards; i++) {
            CreateArtistCards(CreateArtist());

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

    Artist CreateArtist() {
        Artist newArtist = new Artist();
        int randNum = Random.Range(0, maleNames.Length);
        newArtist.artistName = maleNames[randNum];
        newArtist.artistAge = Random.Range(18, 50);
        newArtist.styleStat = Random.Range(0.0f, 10.0f);
        newArtist.talentStat = Random.Range(0.0f, 10.0f);
        return newArtist;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject managmentScreen;
    public GameObject artistChooseScreen;
    public GameObject producerChooseScreen;
    public GameObject makeSongScreen;

    public Text moneyText;
    public Text artistNumText;
    public float totalMoney = 0.0f;
    public int numberOfArtists = 0;

    public List<Artist> listOfSignedArtists = new List<Artist>();
    public List<Producer> listOfHiredProducers = new List<Producer>();
    public List<Song> listOfProducedSongs = new List<Song>();
    
    public string[] genresList;
    

    private void Update()
    {
        moneyText.text = "$" + totalMoney.ToString();
    }


    public void SignArtist(Artist newArtist) {
        listOfSignedArtists.Add(newArtist);
    }

    public void HireProducer(Producer newProducer) {
        listOfHiredProducers.Add(newProducer);
    }

    public void AddProducedSong(Song newSong) {
        listOfProducedSongs.Add(newSong);

    }

    public void DisableAllScreen() {
        artistChooseScreen.SetActive(false);
        producerChooseScreen.SetActive(false);
        managmentScreen.SetActive(false);
        makeSongScreen.SetActive(false);
    }

    public void ActiateOneScreen(GameObject newScreen) {
        newScreen.SetActive(true);

    }


    public void ChangeMoney(float newMoney) {
        totalMoney += newMoney;

    }
}

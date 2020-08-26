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
    public GameObject startScreen;
    public GameObject mainMenu;
    public GameObject gameOverScreen;

    public Text moneyText;
    public float totalMoney = 0.0f;
    public Text recordLabelNameTxt;

    public List<Artist> listOfSignedArtists = new List<Artist>();
    public List<Producer> listOfHiredProducers = new List<Producer>();
    public List<Song> listOfProducedSongs = new List<Song>();
    
    public string[] genresList;


    public string recordLabelName;

    public FindArtistScreen fAS;
    public FindProducersScreen fPS;
    public MakeSongScreen mSS;
    public SongManagment sM;

    


    private void Update()
    {
        moneyText.text = "$" + totalMoney.ToString("F2");
        recordLabelNameTxt.text = recordLabelName;

        if (totalMoney < 0) {
            GameOver();

        }
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
        gameOverScreen.SetActive(false);
        startScreen.SetActive(false);
    }

    public void ActiateOneScreen(GameObject newScreen) {
        newScreen.SetActive(true);

    }


    public void ChangeMoney(float newMoney) {
        totalMoney += newMoney;

    }

    public void FireArtist(Artist theArtist) {
        listOfSignedArtists.Remove(theArtist);

    }

    public void SetRecordLabelName(string value) {
        recordLabelName = value;

    }

    public void StartGame() {
        startScreen.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void GameOver() {

        DisableAllScreen();
        mainMenu.SetActive(false);
        ActiateOneScreen(gameOverScreen);
        listOfHiredProducers.Clear();
        listOfProducedSongs.Clear();
        listOfSignedArtists.Clear();
        fAS.DestroyCards();
        fPS.DestroyCards();
        mSS.ClosePopUp();
        sM.ClosePopUpWindow();

        totalMoney = 5000;
    }
}

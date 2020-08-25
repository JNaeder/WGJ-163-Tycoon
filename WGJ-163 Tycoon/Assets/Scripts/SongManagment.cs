using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongManagment : MonoBehaviour
{

    public GameManager gM;
    public ReleaseSong rS;

    public GameObject songManagmentButton;
    public GameObject detailWindow;
    public GameObject releasedSongPopUp;
    public GameObject marketingPopUp;

    public Transform songList;

    public Song selectedSong;




    public Text songTitle, songGenre, songArtist, songProducer, songHype;
    public Image songCatchiness, songPolish, songUniqness;

    public Text popUpSongTitle, popUpSongArtist, popUpSongProducer, popUpSongGenre, popUpSongChartNum, popUpSongMoney;


    private void Update()
    {
        SetPercBars();
    }
    private void OnEnable()
    {
        DeleteList();
        MakeList();
    }

    public void MakeList()
    {
        foreach (Song s in gM.listOfProducedSongs)
        {
            if (s.currentSongState == Song.songState.written)
            {
                GameObject newButton = Instantiate(songManagmentButton, Vector2.zero, Quaternion.identity, songList) as GameObject;
                Text buttonText = newButton.GetComponentInChildren<Text>();
                ManagmentButton buttonManagmentButton = newButton.GetComponent<ManagmentButton>();
                buttonManagmentButton.buttonSong = s;
                buttonText.text = s.songName;
            }

        }


    }

    public void DeleteList()
    {
        Button[] listOfButtons = songList.GetComponentsInChildren<Button>();

        foreach (Button b in listOfButtons)
        {
            Destroy(b.gameObject);
        }

    }

    void SetPercBars()
    {
        float catchinessPerc = selectedSong.catchy / 10;
        float polishPerc = selectedSong.polish / 10;
        float uniqnessPerc = selectedSong.unique / 10;

        Vector3 catchinessScale = songCatchiness.rectTransform.localScale;
        catchinessScale.x = catchinessPerc;
        songCatchiness.rectTransform.localScale = catchinessScale;

        Vector3 polishScale = songPolish.rectTransform.localScale;
        polishScale.x = polishPerc;
        songPolish.rectTransform.localScale = polishScale;

        Vector3 uniqnessScale = songUniqness.rectTransform.localScale;
        uniqnessScale.x = uniqnessPerc;
        songUniqness.rectTransform.localScale = uniqnessScale;


    }


    public void ShowSongDetails(Song theSong)
    {
        detailWindow.SetActive(true);
        songTitle.text = theSong.songName;
        songArtist.text = theSong.theArtist.artistName;
        songProducer.text = theSong.theProducer.producerName;
        songGenre.text = theSong.genre;
        songHype.text = theSong.hype.ToString("F1");


    }

    public void SelectSong(Song theSong) {
        selectedSong = theSong;
    }

    public void ReleaseSong() {
        CalculateSongSuccess();
        ReleaseSongPopUp(selectedSong);
        selectedSong.currentSongState = Song.songState.released;
        detailWindow.SetActive(false);
        DeleteList();
        MakeList();
        

    }

    public void TrashSong() {
        gM.listOfProducedSongs.Remove(selectedSong);
        DeleteList();
        MakeList();
        detailWindow.SetActive(false);

    }

    public void CalculateSongSuccess() {
        rS.CalculateSongSuccess(selectedSong);


    }

    public void ReleaseSongPopUp(Song theSong) {
        releasedSongPopUp.SetActive(true);
        popUpSongTitle.text = theSong.songName;
        popUpSongArtist.text = theSong.theArtist.artistName;
        popUpSongProducer.text = theSong.theProducer.producerName;
        popUpSongGenre.text = theSong.genre;
        popUpSongChartNum.text = "#" + theSong.chartNum.ToString();
        popUpSongMoney.text = "$" + theSong.moneyEarned.ToString("F2");

    }

    public void ClosePopUpWindow() {
        releasedSongPopUp.SetActive(false);
        marketingPopUp.SetActive(false);
    }

    public void ShowMarketingPopUp() {
        marketingPopUp.SetActive(true);

    }
}

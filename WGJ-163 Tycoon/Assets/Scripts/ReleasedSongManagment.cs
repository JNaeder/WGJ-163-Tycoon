using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReleasedSongManagment : MonoBehaviour
{

    public GameManager gM;

    public GameObject releasedSongManagmentButton;
    public GameObject detailWindow;

    public Transform songList;

    public Song selectdSong;




    public Text songTitle, songGenre, songSuccessNum, songArtist, songProducer;



    private void OnEnable()
    {
        DeleteList();
        MakeList();
    }

    public void MakeList()
    {
        foreach (Song s in gM.listOfProducedSongs)
        {
            if (s.currentSongState == Song.songState.released)
            {
                GameObject newButton = Instantiate(releasedSongManagmentButton, Vector2.zero, Quaternion.identity, songList) as GameObject;
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


    public void ShowSongDetails(Song theSong)
    {
        detailWindow.SetActive(true);
        songTitle.text = theSong.songName;
        songArtist.text = theSong.theArtist.artistName;
        songProducer.text = theSong.theProducer.producerName;
        songGenre.text = theSong.genre;
        songSuccessNum.text = theSong.chartNum.ToString();


    }

    public void SelectSong(Song theSong) {
        selectdSong = theSong;

    }
}

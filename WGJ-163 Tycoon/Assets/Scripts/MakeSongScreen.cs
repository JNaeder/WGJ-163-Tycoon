using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeSongScreen : MonoBehaviour
{
    public GameManager gM;
    MakeASong mAS;

    public Artist selectedArtist;
    public Producer selectedProducer;
    public string selectedGenre;

    public float studioExpense = 100.0f;
    public Text studioExpenseUI;

    public Button makeSongButton;

    public GameObject songCreatedPopUp;
    public Text popUpSongName, popUpSongGenre, popUpSongArtist, popUpSongProducer, popUpSongCatchiness, popUpSongPolish, popUpSongUniqness, popUpSongHype;


    private void Start()
    {
        mAS = GetComponent<MakeASong>();
    }

    private void Update()
    {
        if (selectedArtist == null || selectedProducer == null || selectedGenre == "")
        {
            makeSongButton.interactable = false;
        }
        else {
            makeSongButton.interactable = true;
        }

        studioExpenseUI.text = "$" + studioExpense.ToString("F2");

    }


    public void CreateSong() {
        mAS.CreateSong(selectedArtist, selectedProducer, selectedGenre, studioExpense);
        gM.totalMoney -= studioExpense;
        DeselectAll();
        

    }

    void DeselectAll() {
        selectedArtist = null;
        selectedProducer = null;
        selectedGenre = "";

    }

    public void ShowPopUp(Song theSong) {
        songCreatedPopUp.SetActive(true);
        popUpSongName.text = theSong.songName;
        popUpSongGenre.text = theSong.genre;
        popUpSongArtist.text = theSong.theArtist.artistName;
        popUpSongProducer.text = theSong.theProducer.producerName;
        popUpSongCatchiness.text = theSong.catchy.ToString("F1");
        popUpSongPolish.text = theSong.polish.ToString("F1");
        popUpSongUniqness.text = theSong.unique.ToString("F1");
        popUpSongHype.text = theSong.hype.ToString("F1");

    }

    public void ClosePopUp() {
        songCreatedPopUp.SetActive(false);

    }

    public void ChangeStudioExpense(float expense) {
        studioExpense = expense;

    }
    



}

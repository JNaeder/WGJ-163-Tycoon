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

    public Button makeSongButton;

    private void Start()
    {
        mAS = GetComponent<MakeASong>();
    }

    private void Update()
    {
        if (selectedArtist == null || selectedProducer == null || selectedGenre == null)
        {
            makeSongButton.interactable = false;
        }
        else {
            makeSongButton.interactable = true;
        }
    }


    public void CreateSong() {
        mAS.CreateSong(selectedArtist, selectedProducer, selectedGenre);

    }

    



}

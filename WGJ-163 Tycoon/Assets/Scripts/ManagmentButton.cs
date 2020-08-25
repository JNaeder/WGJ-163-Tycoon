using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagmentButton : MonoBehaviour
{

    ArtistManagment aM;
    ProducerManagment pM;
    SongManagment sM;
    ReleasedSongManagment rSM;

    public Artist buttonArtist;
    public Producer buttonProducer;
    public Song buttonSong;


    // Start is called before the first frame update
    void Start()
    {
        aM = FindObjectOfType<ArtistManagment>();
        pM = FindObjectOfType<ProducerManagment>();
        sM = FindObjectOfType<SongManagment>();
        rSM = FindObjectOfType<ReleasedSongManagment>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ArtistDetails() {
        aM.SelectArtist(buttonArtist);
        aM.ShowArtistDetails(buttonArtist);

    }

    public void ProducerDetails() {
        pM.SelectProducer(buttonProducer);
        pM.ShowProducerDetails(buttonProducer);

    }

    public void SongDetails() {
        sM.SelectSong(buttonSong);
        sM.ShowSongDetails(buttonSong);
    }

    public void ReleasedSongDetails() {
        rSM.SelectSong(buttonSong);
        rSM.ShowSongDetails(buttonSong);

    }
}

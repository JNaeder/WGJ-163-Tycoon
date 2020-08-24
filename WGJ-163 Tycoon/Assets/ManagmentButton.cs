using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagmentButton : MonoBehaviour
{

    ArtistManagment aM;

    public Artist buttonArtist;
    public Producer buttonProducer;
    public string buttonGenre;


    // Start is called before the first frame update
    void Start()
    {
        aM = FindObjectOfType<ArtistManagment>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ArtistDetails() {
        aM.ShowArtistDetails(buttonArtist);

    }
}

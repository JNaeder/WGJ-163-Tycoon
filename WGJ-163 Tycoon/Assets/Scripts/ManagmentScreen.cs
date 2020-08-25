using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagmentScreen : MonoBehaviour
{
    public GameObject artistScreen, producerScreen, songScreen, releasedSongScreen;
    public GameObject artistDetail, producerDetail, songDetail, releasedDetail;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowScreen(GameObject theScreen) {


        artistScreen.SetActive(false);
        producerScreen.SetActive(false);
        songScreen.SetActive(false);
        releasedSongScreen.SetActive(false);
        artistDetail.SetActive(false);
        producerDetail.SetActive(false);
        songDetail.SetActive(false);
        releasedDetail.SetActive(false);

        theScreen.SetActive(true);

    }

    
}

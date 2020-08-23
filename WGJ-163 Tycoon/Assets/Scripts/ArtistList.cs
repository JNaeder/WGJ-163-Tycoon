using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtistList : MonoBehaviour
{

    GameManager gM;

    public GameObject artistListButton;



    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();
        
    }

    private void OnEnable()
    {
        DeleteArtistList();
        MakeList();
    }


    public void MakeList() {
            foreach (Artist a in gM.listOfSignedArtists)
            {
                GameObject newButton = Instantiate(artistListButton, Vector2.zero, Quaternion.identity, transform) as GameObject;
                Text buttonText = newButton.GetComponentInChildren<Text>();
                buttonText.text = a.artistName;

            }


    }

    public void DeleteArtistList() {
        Button[] listOfButtons = GetComponentsInChildren<Button>();

        foreach (Button b in listOfButtons) {
            Destroy(b.gameObject);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenreList : MonoBehaviour
{

    public GameManager gM;

    public GameObject genreListButton;

    
    private void OnEnable()
    {
        DeleteGenreList();
        MakeList();
    }


    public void MakeList()
    {
        foreach (string s in gM.genresList)
        {
            GameObject newButton = Instantiate(genreListButton, Vector2.zero, Quaternion.identity, transform) as GameObject;
            Text buttonText = newButton.GetComponentInChildren<Text>();
            ListButton buttonListButton = newButton.GetComponent<ListButton>();

            buttonListButton.buttonGenre = s;
            buttonText.text = s;

        }


    }

    public void DeleteGenreList()
    {
        Button[] listOfButtons = GetComponentsInChildren<Button>();

        foreach (Button b in listOfButtons)
        {
            Destroy(b.gameObject);
        }

    }
}

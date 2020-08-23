using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProducerList: MonoBehaviour
{

    GameManager gM;

    public GameObject producerListButton;



    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();

    }

    private void OnEnable()
    {
        DeleteProducerList();
        MakeList();
    }


    public void MakeList()
    {
        foreach (Producer p in gM.listOfHiredProducers)
        {
            GameObject newButton = Instantiate(producerListButton, Vector2.zero, Quaternion.identity, transform) as GameObject;
            Text buttonText = newButton.GetComponentInChildren<Text>();
            buttonText.text = p.producerName;

        }


    }

    public void DeleteProducerList()
    {
        Button[] listOfButtons = GetComponentsInChildren<Button>();

        foreach (Button b in listOfButtons)
        {
            Destroy(b.gameObject);
        }

    }
}

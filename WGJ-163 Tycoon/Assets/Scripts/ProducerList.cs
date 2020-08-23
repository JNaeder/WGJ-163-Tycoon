using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProducerList: MonoBehaviour
{

    public GameManager gM;

    public GameObject producerListButton;



    // Start is called before the first frame update
    void Start()
    {

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
            ListButton buttonListButton = newButton.GetComponent<ListButton>();

            buttonListButton.buttonProducer = p;
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

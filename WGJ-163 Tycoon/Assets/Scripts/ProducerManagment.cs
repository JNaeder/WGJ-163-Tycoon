using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProducerManagment : MonoBehaviour
{

    public GameManager gM;

    public GameObject producerManagmentButton;
    public GameObject detailWindow;

    public Transform producerList;

    public Producer selectedProducer;



    public Text producerName, producerAge, producerBrand, producerTalent, producerGenre;
    public Image producerImage;



    private void OnEnable()
    {
        DeleteList();
        MakeList();
    }

    public void MakeList()
    {
        foreach (Producer p in gM.listOfHiredProducers)
        {
            GameObject newButton = Instantiate(producerManagmentButton, Vector2.zero, Quaternion.identity, producerList) as GameObject;
            Text buttonText = newButton.GetComponentInChildren<Text>();
            ManagmentButton buttonManagmentButton = newButton.GetComponent<ManagmentButton>();
            buttonManagmentButton.buttonProducer = p;
            buttonText.text = p.producerName;

        }


    }

    public void DeleteList()
    {
        Button[] listOfButtons = producerList.GetComponentsInChildren<Button>();

        foreach (Button b in listOfButtons)
        {
            Destroy(b.gameObject);
        }

    }


    public void ShowProducerDetails(Producer theProducer)
    {
        detailWindow.SetActive(true);
        producerName.text = theProducer.producerName;
        producerAge.text = theProducer.producerAge.ToString();
        producerBrand.text = theProducer.producerBrand.ToString("F1");
        producerTalent.text = theProducer.producerTalent.ToString("F1");
        producerGenre.text = theProducer.genre;
        producerImage.sprite = theProducer.producerImage;

    }

    public void SelectProducer(Producer theProducer) {
        selectedProducer = theProducer;
    }

    public void FireProducer() {
        gM.listOfHiredProducers.Remove(selectedProducer);
        selectedProducer = null;
        DeleteList();
        MakeList();
        detailWindow.SetActive(false);

    }
}

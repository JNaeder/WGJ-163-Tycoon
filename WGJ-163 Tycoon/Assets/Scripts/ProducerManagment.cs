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



    public Text producerName, producerGenre;
    public Image producerImage, producerTalent, producerBrand;


    private void Update()
    {
        if (selectedProducer != null)
        {
            SetPercBars();
        }
    }
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
    void SetPercBars()
    {
        float talentPerc = selectedProducer.producerTalent / 10;
        float stylePerc = selectedProducer.producerBrand / 10;
        Vector3 talentScale = producerTalent.rectTransform.localScale;
        talentScale.x = talentPerc;
        producerTalent.rectTransform.localScale = talentScale;
        Vector3 styleScale = producerBrand.rectTransform.localScale;
        styleScale.x = stylePerc;
        producerBrand.rectTransform.localScale = styleScale;


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

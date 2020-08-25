using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProducerScript : MonoBehaviour
{
    public Producer theProducer;

    public Text producerName;
    public Text producerAge;
    public Text producerTalent;
    public Text producerBrand;
    public Text producerGenre;
    public Text producerCost;
    public Image producerImage;

    GameManager gM;
    FindProducersScreen fPS;

    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();
        fPS = FindObjectOfType<FindProducersScreen>();


    }

    // Update is called once per frame
    void LateUpdate()
    {
        producerName.text = theProducer.producerName;
        producerAge.text = theProducer.producerAge.ToString();
        producerTalent.text = theProducer.producerTalent.ToString("F1");
        producerBrand.text = theProducer.producerBrand.ToString("F1");
        producerGenre.text = theProducer.genre;
        producerCost.text = "$" + theProducer.hireCost.ToString("F2");
        producerImage.sprite = theProducer.producerImage;
    }

    public void SelectCard()
    {
        fPS.selectedCard = this.gameObject;
    }

    IEnumerator WaitAndDeselect()
    {
        yield return new WaitForSeconds(0.1f);
        fPS.selectedCard = null;
    }

    public void DeselectCard()
    {
        StartCoroutine(WaitAndDeselect());
    }
}

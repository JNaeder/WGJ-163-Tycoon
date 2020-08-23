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

    GameManager gM;

    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();


    }

    // Update is called once per frame
    void LateUpdate()
    {
        producerName.text = theProducer.producerName;
        producerAge.text = theProducer.producerAge.ToString();
        producerTalent.text = theProducer.producerTalent.ToString();
        producerBrand.text = theProducer.producerBrand.ToString();
    }


    public void ChooseCard()
    {
        gM.HireProducer(theProducer);

    }
}

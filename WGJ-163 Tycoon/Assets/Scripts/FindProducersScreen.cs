using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindProducersScreen : MonoBehaviour
{

    public GameManager gM;

    public GameObject producerCard;

    public Transform cardParent;

    public TextAsset producerNamesTxt;
    string[] producerNames;

    public Button chooseProducerButton;

    [HideInInspector]
    public GameObject selectedCard;

    private void Start()
    {
        producerNames = producerNamesTxt.text.Split('\n');
    }

    private void Update()
    {
        if (selectedCard == null)
        {
            chooseProducerButton.interactable = false;
        }
        else
        {
            chooseProducerButton.interactable = true;
        }

    }

    public void CreateMutipleCards(int numOfCards)
    {
        DestroyCards();
        for (int i = 0; i < numOfCards; i++)
        {
            CreateProducerCards(CreateRandomProducer());

        }


    }

    public void DestroyCards()
    {
        ProducerScript[] cardsInParent = cardParent.GetComponentsInChildren<ProducerScript>();
        foreach (ProducerScript t in cardsInParent)
        {
            Destroy(t.gameObject);
        }
    }


    void CreateProducerCards(Producer thisProducer)
    {
        GameObject newProducer = Instantiate(producerCard, Vector2.zero, Quaternion.identity, cardParent) as GameObject;
        ProducerScript producerS = newProducer.GetComponent<ProducerScript>();
        producerS.theProducer = thisProducer;

    }


    Producer CreateRandomProducer()
    {
        Producer newProducer = ScriptableObject.CreateInstance<Producer>();
        int randNum = Random.Range(0, producerNames.Length);
        newProducer.producerName = producerNames[randNum];
        newProducer.producerAge = Random.Range(18, 50);
        newProducer.producerTalent = Random.Range(0.0f, 10.0f);
        newProducer.producerBrand = Random.Range(0.0f, 10.0f);
        return newProducer;


    }

    public void ChooseProducer()
    {
        Producer newProducer = selectedCard.GetComponent<ProducerScript>().theProducer;
        gM.HireProducer(newProducer);
        Destroy(selectedCard);

    }
}

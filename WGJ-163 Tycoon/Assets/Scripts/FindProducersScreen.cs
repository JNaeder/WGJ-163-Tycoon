﻿using System.Collections;
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

    public Sprite[] producerImages;

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
        int randNum2 = Random.Range(0, producerImages.Length);
        newProducer.producerImage = producerImages[randNum2];

        newProducer.producerAge = Random.Range(18, 50);
        newProducer.producerTalent = Random.Range(0.0f, 10.0f);
        newProducer.producerBrand = Random.Range(0.0f, 10.0f);
        int randNum3 = Random.Range(0, gM.genresList.Length);
        newProducer.genre = gM.genresList[randNum3];
        newProducer.hireCost = CalculateHireCost(newProducer.producerTalent, newProducer.producerBrand);
        return newProducer;


    }

    public void ChooseProducer()
    {
        Producer newProducer = selectedCard.GetComponent<ProducerScript>().theProducer;
        gM.totalMoney -= newProducer.hireCost;
        gM.HireProducer(newProducer);
        Destroy(selectedCard);

    }

    public float CalculateHireCost(float talent, float brand) {
        float newCost = talent * brand * 50;
        return newCost;


    }
}

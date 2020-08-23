using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindProducersScreen : MonoBehaviour
{

    public Producer[] listOfProducers;

    public GameObject producerCard;

    public Transform cardParent;

    public void CreateMutipleCards(int numOfCards)
    {
        DestroyCards();
        for (int i = 0; i < numOfCards; i++)
        {
            CreateProducerCards(ChooseRandomProducer());

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


    Producer ChooseRandomProducer()
    {
        int randNum = Random.Range(0, listOfProducers.Length);

        return listOfProducers[randNum];


    }
}

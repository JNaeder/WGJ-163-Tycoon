using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProducerScript : MonoBehaviour
{
    public Producer theProducer;

    public Text producerName;
    public Text producerAge;
    public Text producerGenre;
    public Text producerCost;
    public Image producerImage;
    public Image producerBrand;
    public Image producerTalent;

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
        producerGenre.text = theProducer.genre;
        producerCost.text = "$" + theProducer.hireCost.ToString("F2");
        producerImage.sprite = theProducer.producerImage;
        SetPercBars();
    }

    void SetPercBars()
    {
        float talentPerc = theProducer.producerTalent / 10;
        float stylePerc = theProducer.producerBrand / 10;
        Vector3 talentScale = producerTalent.rectTransform.localScale;
        talentScale.x = talentPerc;
        producerTalent.rectTransform.localScale = talentScale;
        Vector3 styleScale = producerBrand.rectTransform.localScale;
        styleScale.x = stylePerc;
        producerBrand.rectTransform.localScale = styleScale;


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

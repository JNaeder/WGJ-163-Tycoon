using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Producer", menuName ="Producer")]
public class Producer : ScriptableObject
{
    public string producerName;
    public int producerAge;
    public float producerTalent;
    public float producerBrand;
    public string genre;
    public float hireCost;

    public Sprite producerImage;
}

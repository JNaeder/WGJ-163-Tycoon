using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : ScriptableObject
{
    public string songName;
    public Artist theArtist;
    public Producer theProducer;
    public string genre;

    public int chartNum;
    public float moneyEarned;

    public float catchy;
    public float polish;
    public float unique;
    public float hype;



    public enum songState {written, released}
    public songState currentSongState;


}

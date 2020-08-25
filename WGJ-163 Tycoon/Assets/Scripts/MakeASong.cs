using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeASong : MonoBehaviour
{
    public GameManager gM;
    public MakeSongScreen mSS;

    Song newSong;

    public TextAsset hiphopSongNames, rockSongNames, countrySongNames, popSongNames, rBSongNames;


    public void CreateSong(Artist theArtist, Producer theProducer, string theGenre, float studioExpense) {
        //Song Name Generator
        string songName = MakeSongTitle(theGenre);
        
        // Total Talent (Max is 20)
        float talentScore = theArtist.talentStat + theProducer.producerTalent;


        float genrePenalty = 0;

        //Check Genre Match
        if (theGenre != theArtist.genre) {
            genrePenalty += 4;
        }
        if (theGenre != theProducer.genre) {
            genrePenalty += 5;
        }


        //Make Catchiness (Talent)
        float randNum1 = Random.Range(0f, 2f);
        float catchiness = ((talentScore / 2) * randNum1) - genrePenalty;
        catchiness = Mathf.Clamp(catchiness, 0f, 10f);

        //Make Polish (Involve Studio Expense)
        float randNum2 = Random.Range(-2f, 2f);
        float polish = ((51 - (5000f / studioExpense))/ 7 ) + randNum2;
        polish = Mathf.Clamp(polish, 0f, 10f);

        //Make Unique (Random and Talent)
        float randNum3 = Random.Range(-5f, 5f);
        float unique = (talentScore / 2) - genrePenalty;
        unique = Mathf.Clamp(unique, 0f, 10f);

        //Make Hype (Brand)
        float hype = theProducer.producerBrand + theArtist.styleStat + Random.Range(-4f,4f);


        // Make the Song
        MakeNewSong(theArtist, theProducer, theGenre, songName, catchiness, polish, unique, hype);
    }





    string MakeSongTitle(string theGenre) {

        if (theGenre == "Hip-Hop")
        {
            string[] songNames = hiphopSongNames.text.Split('\n');
            return ChooseRandomSong(songNames);

        }
        else if (theGenre == "Rock")
        {
            string[] songNames = rockSongNames.text.Split('\n');
            return ChooseRandomSong(songNames);
        }
        else if (theGenre == "Country")
        {
            string[] songNames = countrySongNames.text.Split('\n');
            return ChooseRandomSong(songNames);
        }
        else if (theGenre == "Pop")
        {
            string[] songNames = popSongNames.text.Split('\n');
            return ChooseRandomSong(songNames);
        }
        else if (theGenre == "R&B")
        {
            string[] songNames = rBSongNames.text.Split('\n');
            return ChooseRandomSong(songNames);
        }
        else {

            string[] songNames = hiphopSongNames.text.Split('\n');
            return ChooseRandomSong(songNames);
        }

       
    }

    string ChooseRandomSong(string[] theSongNames) {
        int randNum = Random.Range(0, theSongNames.Length);
        string finalSongName = theSongNames[randNum];
        return finalSongName;

    }


    void MakeNewSong(Artist theArtist, Producer theProducer, string theGenre, string theSongName, float catchy, float polish, float unique, float hype) {
        newSong = ScriptableObject.CreateInstance<Song>();

        newSong.theArtist = theArtist;
        newSong.theProducer = theProducer;
        newSong.genre = theGenre;
        newSong.songName = theSongName;

        newSong.catchy = catchy;
        newSong.polish = polish;
        newSong.unique = unique;
        newSong.hype = hype;

        newSong.currentSongState = Song.songState.written;

        gM.AddProducedSong(newSong);
        mSS.ShowPopUp(newSong);

    }


}

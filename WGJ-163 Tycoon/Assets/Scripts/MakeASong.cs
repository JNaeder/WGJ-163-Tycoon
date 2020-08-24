using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeASong : MonoBehaviour
{
    public GameManager gM;

    Song newSong;


    public void CreateSong(Artist theArtist, Producer theProducer, string theGenre, string songName) {

        

        float talentScore = theArtist.talentStat + theProducer.producerTalent;

        int ageInfraction;
        if (theArtist.artistAge > 25)
        {
            ageInfraction = theArtist.artistAge - 25 * 2;
        }
        else {
            ageInfraction = 1;
        }

        float successNum = talentScore * ((theArtist.styleStat * theProducer.producerBrand) / ageInfraction);



        MakeNewSong(theArtist, theProducer, theGenre, successNum, songName);
        Debug.Log(newSong.theArtist.artistName + "and " + newSong.theProducer.producerName + " made the song '" + newSong.songName + "' in the style of " + newSong.genre + " and topped the charts at " + newSong.chartNum);
    }


    void MakeNewSong(Artist theArtist, Producer theProducer, string theGenre, float successNum, string theSongName) {
        newSong = ScriptableObject.CreateInstance<Song>();
        newSong.theArtist = theArtist;
        newSong.theProducer = theProducer;
        newSong.genre = theGenre;
        newSong.chartNum = Mathf.RoundToInt(successNum);
        newSong.songName = theSongName;

        gM.AddProducedSong(newSong);

    }
}

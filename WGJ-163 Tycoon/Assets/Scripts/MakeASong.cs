using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeASong : MonoBehaviour
{
    public GameManager gM;

    Song newSong;


    public void CreateSong(Artist theArtist, Producer theProducer, string theGenre) {

        

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



        MakeNewSong(theArtist, theProducer, theGenre, successNum);
        Debug.Log("Made a song with " + newSong.theArtist.artistName + "and " + newSong.theProducer.producerName + " in the style of " + newSong.genre + " and topped the charts at " + newSong.chartNum);
    }


    void MakeNewSong(Artist theArtist, Producer theProducer, string theGenre, float successNum) {
        newSong = ScriptableObject.CreateInstance<Song>();
        newSong.theArtist = theArtist;
        newSong.theProducer = theProducer;
        newSong.genre = theGenre;
        newSong.chartNum = Mathf.RoundToInt(successNum);

        gM.AddProducedSong(newSong);

    }
}

using System.Collections;
using UnityEngine;

namespace Assets.Code.Score
{
    public class RecordController : MonoBehaviour
    {
        [SerializeField] Record playerRecord;

        public long BestScore => playerRecord.RecordScore;

        public void UpdateScore(long newScore)
        {
            if (playerRecord.RecordScore < newScore)
            {
                playerRecord.RecordScore = newScore;
            }
        }
       
        
    }
}
using System.Collections;
using UnityEngine;

namespace Assets.Code.Score
{
    public class RecordController : MonoBehaviour
    {
        [SerializeField] Record playerRecord;

        public void UpdateScore(long newScore)
        {
            if ((playerRecord != null) && (playerRecord.RecordScore < newScore))
            {
                playerRecord.RecordScore = newScore;
            }
        }
    }
}
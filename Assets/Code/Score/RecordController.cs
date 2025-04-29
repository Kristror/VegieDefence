using System.Collections;
using UnityEngine;

namespace Assets.Code.Score
{
    public class RecordController : MonoBehaviour
    {
        [SerializeField] Record playerRecord;
        [SerializeField] Main main;

        public long OnionRecordScore => playerRecord.OnionRecordScore;
        public long PotatoRecordScore => playerRecord.PotatoRecordScore;
        public long PumpkinRecordScore => playerRecord.PumpkinRecordScore;

        public long BestScore()
        {
            switch (main.PlayerClass)
            {
                case Player.ClassesEnum.Onion:
                    return playerRecord.OnionRecordScore;

                case Player.ClassesEnum.Potato:
                    return playerRecord.PotatoRecordScore;

                case Player.ClassesEnum.Pumpkin:
                    return playerRecord.PumpkinRecordScore;

                default: return 0;
            }
        }

        public void UpdateScore(long newScore)
        {
            switch (main.PlayerClass)
            {
                case Player.ClassesEnum.Onion:
                    if (playerRecord.OnionRecordScore < newScore)
                    {
                        playerRecord.OnionRecordScore = newScore;
                    }
                break;

                case Player.ClassesEnum.Potato:
                    if (playerRecord.PotatoRecordScore < newScore)
                    {
                        playerRecord.PotatoRecordScore = newScore;
                    }
                break;

                case Player.ClassesEnum.Pumpkin:
                    if (playerRecord.PumpkinRecordScore < newScore)
                    {
                        playerRecord.PumpkinRecordScore = newScore;
                    }
                break;
            }   
        }     
    }
}
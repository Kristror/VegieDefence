using System.Numerics;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Score
{
    [CreateAssetMenu(fileName = "PlayerRecord", menuName = "MyTools/PlayerRecord")]
    public class Record : ScriptableObject
    {
        [SerializeField] private long onionRecordScore;
        [SerializeField] private long potatoRecordScore;
        [SerializeField] private long pumpkinRecordScore;

        public long OnionRecordScore
        {
            get
            {
                return onionRecordScore;
            }
            set
            {
                if (value > 0) onionRecordScore = value;
            }
        }

        public long PotatoRecordScore
        {
            get
            {
                return potatoRecordScore;
            }
            set
            {
                if (value > 0) potatoRecordScore = value;
            }
        }
        
        public long PumpkinRecordScore
        {
            get
            {
                return pumpkinRecordScore;
            }
            set
            {
                if (value > 0) pumpkinRecordScore = value;
            }
        }

    }
}
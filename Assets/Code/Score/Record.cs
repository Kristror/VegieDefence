using System.Numerics;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Score
{
    [CreateAssetMenu(fileName = "PlayerRecord", menuName = "MyTools/PlayerRecord")]
    public class Record : ScriptableObject
    {       

            [SerializeField] private long recordScore;
            public long RecordScore
            {
                get
                {
                    return recordScore;
                }
                set
                {   
                    if (value > 0) recordScore = value;
                }
            }

            
    }
}
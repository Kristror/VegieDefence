using System;
using UnityEngine;

namespace Assets.Code.DangerLevels
    {/// <summary>
     /// Данный класс отвечает за контроль уровня опасности.
     /// Уровень увеличивается через определенное количество секунд и отвечает за здоровье и количество противников.
     /// </summary>
    public class DangerLevelController : MonoBehaviour
    {   
        
        private int dangerLevel = 0;
        /// <summary>
        /// время для увеличения уровня опасности
        /// </summary>
        private float timeToLevel = 15;
        /// <summary>
        /// Время последнего увеличения уровня опасности
        /// </summary>
        private float timeFromLastLevel = 0;
        /// <summary>
        /// Уровень опасности
        /// </summary>
        public int DangerLevel => dangerLevel;
        /// <summary>
        /// Вызывается когда изменяется уровень опасности 
        /// </summary>
        public Action DangerLevelUpdated;

        public void FrameUpdate()
        {
            if (Time.time - timeFromLastLevel > timeToLevel)
            {
                dangerLevel++;
                timeFromLastLevel  = Time.time;
                DangerLevelUpdated?.Invoke();
            }
        }

    }
}
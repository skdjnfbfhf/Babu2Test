using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Babu2Test
{
    public class GameDataManager : SingleTon<GameDataManager>
    {

        public float speed = 2.0f;
        public float hp = 10f;
        public float maxHp = 10f;
        public int upgrade = 0;
        public int maxUpgrade = 3;
        public int bomb = 0;
        public int maxBomb = 3;

        //적 체력 및 속력
        public float Ehp = 10f;
        public float EmaxHp = 10f;
        public float Espeed = 5f;

    }
}

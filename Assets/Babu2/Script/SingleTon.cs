using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Babu2Test
{
    public class SingleTon<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        
        public static T instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType(typeof(T) as T);
                    DontDestroyOnLoad(instance.gameObject);
                    if(instance != null)
                    {
                        Debug.LogError("현재 씬에서" + typeof(T)
                            + "를 활성화 할 수 없습니다");
                    }
                }
        }

    }
}

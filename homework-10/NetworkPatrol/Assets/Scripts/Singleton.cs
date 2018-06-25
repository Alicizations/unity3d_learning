using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * 单例模式模板，所有的MonoBehaviour对象都用这个模板来实现单实例
 */
namespace Mygame
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {

        protected static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));
                    if (instance == null)
                    {
                        Debug.LogError("An instance of " + typeof(T)
                            + " is needed in the scene, but there is none.");
                    }
                }
                return instance;
            }
        }
    }
}
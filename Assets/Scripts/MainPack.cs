using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyMode { Continuous, DownOnce, Up }

namespace LON_Tools
{
    public class MainPack : MonoBehaviour
    {
        // FixedUpdate
        void FixedUpdate()
        {
            //RBController(this.gameObject, 4, "z", "s", "q", "d");
        }

        /// <summary>
        /// Controller ultra basique fonctionnant avec la physique pour prototyper rapidement.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="speed"></param>
        /// <param name="up"></param>
        /// <param name="down"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="rb"></param>
        public static void RBController(GameObject player, int speed, string up, string down, string left, string right, Rigidbody2D rb = null)
        {
            if(player.GetComponent<Rigidbody2D>() != null)
            {
                if(rb == null)
                {
                    rb = player.GetComponent<Rigidbody2D>();
                }

                if (up != null && Input.GetKey(up))
                {
                    rb.velocity = Vector2.up * speed;
                }
                else if(down != null && Input.GetKey(down))
                {
                    rb.velocity = Vector2.down * speed;
                }
                else if(left != null && Input.GetKey(left))
                {
                    rb.velocity = Vector2.left * speed;
                }
                else if(right != null && Input.GetKey(right))
                {
                    rb.velocity = Vector2.right * speed;
                }
            }
        }

        /// <summary>
        /// Permet d'appeler une fonction un certain nombre de fois, toutes les X secondes.
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="howManyCalls"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        //Ne pas oublier le StartCoroutine pour l'appeler
        public IEnumerator ClampedInvoke(string methodName, int howManyCalls = 15, float delay = 0f)
        {
            if (methodName != null && howManyCalls != 0)
            {
                for (int i = 0; i < howManyCalls; i++)
                {
                    Debug.Log("oooh");
                    Invoke(methodName, 0f);
                    yield return new WaitForSeconds(delay);
                }
            }         
        }

        /// <summary>
        /// Permet à une liste de touches d'effectuer la même action enfonction d'un mode d'appui.
        /// </summary>
        /// <param name="keyCodes"></param>
        /// <param name="keyMode"></param>
        /// <returns></returns>
        public static bool MultipleKey(List<KeyCode> keyCodes, KeyMode keyMode = KeyMode.DownOnce)
        {
            if(keyCodes.Count > 0 && Input.anyKey)
            {
                foreach(KeyCode kc in keyCodes)
                {
                    switch (keyMode)
                    {
                        case KeyMode.Continuous:
                            if (Input.GetKey(kc))
                            {
                                return true;
                            }
                            break;
                        case KeyMode.DownOnce:
                            if (Input.GetKeyDown(kc))
                            {
                                return true;
                            }
                            break;
                    }
                }
            }
            else if(keyCodes.Count > 0 && keyMode == KeyMode.Up)
            {
                foreach (KeyCode kc in keyCodes)
                {
                    if (Input.GetKeyUp(kc))
                    {
                        return true;
                    }
                }
            }
            return false;
        }



        //Singles


        public static IEnumerator SingleMethodDelayer(System.Action _method, float _delay)
        {
            yield return new WaitForSeconds(_delay);

            _method();
        } //.-0
        public static IEnumerator SingleMethodDelayer<T>(System.Action<T> _method, float _delay, T parameter)
        {
            yield return new WaitForSeconds(_delay);

            _method(parameter);
        } //.-1
        public static IEnumerator SingleMethodDelayer<T, U>(System.Action<T, U> _method, float _delay, T parameter1, U parameter2)
        {
            yield return new WaitForSeconds(_delay);

            _method(parameter1, parameter2);
        }   //.-2
        public static IEnumerator SingleMethodDelayer<T, U, V>(System.Action<T, U, V> _method, float _delay, T parameter1, U parameter2, V parameter3)
        {
            yield return new WaitForSeconds(_delay);

            _method(parameter1, parameter2, parameter3);
        } //.-3
        public static IEnumerator SingleMethodDelayer<T, U, V, W>(System.Action<T, U, V, W> _method, float _delay, T parameter1, U parameter2, V parameter3, W parameter4)
        {
            yield return new WaitForSeconds(_delay);

            _method(parameter1, parameter2, parameter3, parameter4);
        } //.-4


        //Doubles

        public static IEnumerator DoubleMethodDelayer(System.Action _method, float _delay, System.Action _method2) //0-0
        {
            _method();

            yield return new WaitForSeconds(_delay);

            _method2();
        }
        public static IEnumerator DoubleMethodDelayer<T>(System.Action _method, float _delay, System.Action<T> _method2, T parameter1) //0-1
        {
            _method();

            yield return new WaitForSeconds(_delay);

            _method2(parameter1);
        }
        public static IEnumerator DoubleMethodDelayer<T, U>(System.Action _method, float _delay, System.Action<T, U> _method2, T parameter1, U parameter2) //0-2
        {
            _method();

            yield return new WaitForSeconds(_delay);

            _method2(parameter1, parameter2);
        }
        public static IEnumerator DoubleMethodDelayer<T, U, V>(System.Action _method, float _delay, System.Action<T, U, V> _method2, T parameter1, U parameter2, V parameter3) //0-3
        {
            _method();

            yield return new WaitForSeconds(_delay);

            _method2(parameter1, parameter2, parameter3);
        }

        public static IEnumerator DoubleMethodDelayer<T>(System.Action<T> _method, T parameter1, float _delay, System.Action _method2) //1-0
        {
            _method(parameter1);

            yield return new WaitForSeconds(_delay);

            _method2();
        }
        public static IEnumerator DoubleMethodDelayer<T, U>(System.Action<T> _method, T parameter1, float _delay, System.Action<U> _method2, U parameter2) //1-1
        {
            _method(parameter1);

            yield return new WaitForSeconds(_delay);

            _method2(parameter2);
        }
        public static IEnumerator DoubleMethodDelayer<T, U, V>(System.Action<T> _method, T parameter1, float _delay, System.Action<U, V> _method2, U parameter2, V parameter3) //1-2
        {
            _method(parameter1);

            yield return new WaitForSeconds(_delay);

            _method2(parameter2, parameter3);
        }
        public static IEnumerator DoubleMethodDelayer<T, U, V, W>(System.Action<T> _method, T parameter1, float _delay, System.Action<U, V, W> _method2, U parameter2, V parameter3, W parameter4) //1-3
        {
            _method(parameter1);

            yield return new WaitForSeconds(_delay);

            _method2(parameter2, parameter3, parameter4);
        }

        public static IEnumerator DoubleMethodDelayer<T, U>(System.Action<T, U> _method, T parameter1, U parameter2, float _delay, System.Action _method2) //2-0
        {
            _method(parameter1, parameter2);

            yield return new WaitForSeconds(_delay);

            _method2();
        }
        public static IEnumerator DoubleMethodDelayer<T, U, V>(System.Action<T, U> _method, T parameter1, U parameter2, float _delay, System.Action<V> _method2, V parameter3) //2-1
        {
            _method(parameter1, parameter2);

            yield return new WaitForSeconds(_delay);

            _method2(parameter3);
        }
        public static IEnumerator DoubleMethodDelayer<T, U, V, W>(System.Action<T, U> _method, T parameter1, U parameter2, float _delay, System.Action<V, W> _method2, V parameter3, W parameter4) //2-2
        {
            _method(parameter1, parameter2);

            yield return new WaitForSeconds(_delay);

            _method2(parameter3, parameter4);
        }
        public static IEnumerator DoubleMethodDelayer<T, U, V, W, X>(System.Action<T, U> _method, T parameter1, U parameter2, float _delay, System.Action<V, W, X> _method2, V parameter3, W parameter4, X parameter5) //2-3
        {
            _method(parameter1, parameter2);

            yield return new WaitForSeconds(_delay);

            _method2(parameter3, parameter4, parameter5);
        }

        public static IEnumerator DoubleMethodDelayer<T, U, V>(System.Action<T, U, V> _method, T parameter1, U parameter2, V parameter3, float _delay, System.Action _method2) //3-0
        {
            _method(parameter1, parameter2, parameter3);

            yield return new WaitForSeconds(_delay);

            _method2();
        }
        public static IEnumerator DoubleMethodDelayer<T, U, V, W>(System.Action<T, U, V> _method, T parameter1, U parameter2, V parameter3, float _delay, System.Action<W> _method2, W parameter4) //3-1
        {
            _method(parameter1, parameter2, parameter3);

            yield return new WaitForSeconds(_delay);

            _method2(parameter4);
        }
        public static IEnumerator DoubleMethodDelayer<T, U, V, W, X>(System.Action<T, U, V> _method, T parameter1, U parameter2, V parameter3, float _delay, System.Action<W, X> _method2, W parameter4, X parameter5) //3-2
        {
            _method(parameter1, parameter2, parameter3);

            yield return new WaitForSeconds(_delay);

            _method2(parameter4, parameter5);
        }
        public static IEnumerator DoubleMethodDelayer<T, U, V, W, X, Y>(System.Action<T, U, V> _method, T parameter1, U parameter2, V parameter3, float _delay, System.Action<W, X, Y> _method2, W parameter4, X parameter5, Y parameter6) //3-3
        {
            _method(parameter1, parameter2, parameter3);

            yield return new WaitForSeconds(_delay);

            _method2(parameter4, parameter5, parameter6);
        }
    }
}

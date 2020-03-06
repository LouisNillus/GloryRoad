using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace LON_MenuArea
{
    public class SceneManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown("escape"))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }

        public void ChooseScene(int index)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(index);
        }

        public void Quit()
        {
            Application.Quit();
            Debug.Log("Application closed");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class CheckInternet : MonoBehaviour
{
    [SerializeField] GameObject errorPage;
    [SerializeField] Text internetText;
    [SerializeField] bool internetCheckBool;

    [SerializeField] bool percentStart;
    [SerializeField] float loadingPercent;

    [SerializeField] Text percentText;

    [SerializeField] Slider slider;

    void Start()
    {
        internetText.text = "";
        errorPage.SetActive(false);
        percentStart = true;
    }

    void Update()
    {
        percentText.text = (loadingPercent.ToString("f0")) + " %";
        slider.value = loadingPercent;

        if(percentStart)
        {
            loadingPercent += 10 * Time.deltaTime;

            if(loadingPercent >= 30f)
            {
                InternetChecking();

                if(internetCheckBool)
                {
                    percentStart = true;
                    loadingPercent += 10 * Time.deltaTime;

                    if(loadingPercent >= 100f)
                    {
                        percentStart = false;
                        loadingPercent = 100;
                        SceneManager.LoadScene("BannerReklam");
                    }
                }

                else if(!internetCheckBool)
                {
                    percentStart = false;
                    loadingPercent += 0;
                }
            }
        }
        else
        {
            loadingPercent += 0;
        }
    }

    void InternetChecking()
    {
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            internetText.text = "Not connected";
            internetCheckBool = false;
            Debug.Log("There isn't internet");
            errorPage.SetActive(true);
        }
        else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            internetText.text = "Connected!";
            internetCheckBool = true;
            Debug.Log("There is internet");
            errorPage.SetActive(false);
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

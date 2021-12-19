using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Text dogrusayitxt, yanlissayitxt, puantxt;

    [SerializeField]
    private GameObject yýldýz1,yýldýz2,yýldýz3;

    public void SonuclarýYazdýr(int dogrusayisi,int yanlissayisi,int puan)
    {
        dogrusayitxt.text = dogrusayisi.ToString();
        yanlissayitxt.text = yanlissayisi.ToString();
        puantxt.text = puan.ToString();

       
        int toplamsoru = dogrusayisi + yanlissayisi;

        if (dogrusayisi < toplamsoru/3)
        {
            yýldýz1.SetActive(false);
            yýldýz2.SetActive(false);
            yýldýz3.SetActive(false);
        }else if(toplamsoru/3 >= dogrusayisi && dogrusayisi < toplamsoru/3*2)
        {
            yýldýz1.SetActive(true);
            yýldýz2.SetActive(false);
            yýldýz3.SetActive(false);
        }
        else if (toplamsoru / 3*2 >= dogrusayisi && dogrusayisi < toplamsoru)
        {
            yýldýz1.SetActive(true);
            yýldýz2.SetActive(true);
            yýldýz3.SetActive(false);
        }else if (dogrusayisi == toplamsoru)
        {
            yýldýz1.SetActive(true);
            yýldýz2.SetActive(true);
            yýldýz3.SetActive(true);

        }





    }

    public void YenidenOyna()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}

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
    private GameObject y�ld�z1,y�ld�z2,y�ld�z3;

    public void Sonuclar�Yazd�r(int dogrusayisi,int yanlissayisi,int puan)
    {
        dogrusayitxt.text = dogrusayisi.ToString();
        yanlissayitxt.text = yanlissayisi.ToString();
        puantxt.text = puan.ToString();

       
        int toplamsoru = dogrusayisi + yanlissayisi;

        if (dogrusayisi < toplamsoru/3)
        {
            y�ld�z1.SetActive(false);
            y�ld�z2.SetActive(false);
            y�ld�z3.SetActive(false);
        }else if(toplamsoru/3 >= dogrusayisi && dogrusayisi < toplamsoru/3*2)
        {
            y�ld�z1.SetActive(true);
            y�ld�z2.SetActive(false);
            y�ld�z3.SetActive(false);
        }
        else if (toplamsoru / 3*2 >= dogrusayisi && dogrusayisi < toplamsoru)
        {
            y�ld�z1.SetActive(true);
            y�ld�z2.SetActive(true);
            y�ld�z3.SetActive(false);
        }else if (dogrusayisi == toplamsoru)
        {
            y�ld�z1.SetActive(true);
            y�ld�z2.SetActive(true);
            y�ld�z3.SetActive(true);

        }





    }

    public void YenidenOyna()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}

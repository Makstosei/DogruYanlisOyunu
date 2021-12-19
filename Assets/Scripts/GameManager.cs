using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public Soru[] sorular;
    private static List<Soru> cevaplanmamissorular;
    private Soru gecerliSoru;

    [SerializeField]
    private Text soruText,dogrucvptext,yanliscevaptext;
    [SerializeField]
    private GameObject dogrubtn, yanlisbtn,sonucPaneli;

    int dogruadet, yanlisadet,toplamPuan;

    SonucManager sonucManager;

    void Start()
    {
        if(cevaplanmamissorular==null || cevaplanmamissorular.Count == 0)
        {

            cevaplanmamissorular = sorular.ToList<Soru>();
        }
        RastgeleSoruSec();
      
    }

    void RastgeleSoruSec()
    {
        dogrubtn.GetComponent<RectTransform>().DOLocalMoveX(-312, 0.2f);
        yanlisbtn.GetComponent<RectTransform>().DOLocalMoveX(312, 0.2f);


        int RandomSoruIndex = Random.Range(0, cevaplanmamissorular.Count);
        gecerliSoru = cevaplanmamissorular[RandomSoruIndex];
        soruText.text = gecerliSoru.soru;

        if (gecerliSoru.dogrumu)
        {
            dogrucvptext.text = "DOGRU CEVAPLADINIZ";
            yanliscevaptext.text = "YANLÝS CEVAPLADINIZ";
        }
        else
        {
            dogrucvptext.text = "YANLÝS CEVAPLADINIZ" ;
            yanliscevaptext.text = "DOGRU CEVAPLADINIZ";
        }

    }

    public void DogrubutonaBasildi()
    {
        if (gecerliSoru.dogrumu)
        {
            dogruadet++;
            toplamPuan += 100;
        }
        else
        {
            yanlisadet++;
        }
        StartCoroutine(SorulararasýGecisRoutine());
        yanlisbtn.GetComponent<RectTransform>().DOLocalMoveX(1000, 0.2f);

    }

    public void YanlisbutonaBasildi()
    {
        if (!gecerliSoru.dogrumu)
        {
            dogruadet++;
            toplamPuan += 100;
        }
        else
        {
            yanlisadet++;
        }
        StartCoroutine(SorulararasýGecisRoutine());
        dogrubtn.GetComponent<RectTransform>().DOLocalMoveX(-1000, 0.2f);
    }



    IEnumerator SorulararasýGecisRoutine()
    {

        cevaplanmamissorular.Remove(gecerliSoru);
        yield return new WaitForSeconds(1f);
        if (cevaplanmamissorular.Count <= 0)
        {
            sonucPaneli.SetActive(true);
            sonucManager = Object.FindObjectOfType<SonucManager>();
            sonucManager.SonuclarýYazdýr(dogruadet, yanlisadet, toplamPuan);
        }
        else
        {
            RastgeleSoruSec();
        }
    }

   


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensBoom : MonoBehaviour
{
    private GameObject[] Lins;
    [SerializeField] private List<LaserLine> listLins = new List<LaserLine>();
    void Start()
    {
        Lins = GameObject.FindGameObjectsWithTag("Lens");
        foreach (GameObject len in Lins)
        {
            listLins.Add(len.GetComponent<LaserLine>());
        }
        if(Lins.Length > 1)
        {
            StartCoroutine(LogicBoom());
            Debug.Log("Zapusk");
        }
    }


    private IEnumerator test()
    {
        while (true)
        {
            Debug.Log("Корутину вызвали!");
            yield return new WaitForSeconds(3f);
        }
    }
    private IEnumerator LogicBoom()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            Debug.Log("Proverka Lens");
            List<LaserLine> isActiveLazer = new List<LaserLine>();
            foreach (LaserLine len in listLins)
            {
                if(len.isActiveLazer)
                    isActiveLazer.Add(len);
            }
            bool LensAllBoom = true;
            if (isActiveLazer.Count == 0) continue;
            foreach (LaserLine len in isActiveLazer)
            {
                if (len.objectHit.tag != "Lens")
                {
                    LensAllBoom = false;
                }
            }
            if(LensAllBoom)
            {
                Debug.LogWarning("Boom");
                Boom(isActiveLazer);
            }
            
            for(int i = 1; i < isActiveLazer.Count; i++)
            {
                GameObject lens1 = isActiveLazer[i].Lens;
                GameObject lens2 = isActiveLazer[i - 1].Lens;
                if (lens1 == null || lens2 == null) break;
                if (isActiveLazer[i].Lens == lens2 && isActiveLazer[i - 1].Lens == lens1)
                {
                    Debug.LogWarning("Boom");

                    Boom(isActiveLazer);
                }
            }

        }
    }

    private void Boom(List<LaserLine> isActiveLazer)
    {
        foreach (LaserLine len in isActiveLazer)
        {
            len.Lens = null;
            len.isActiveLazer = false;
            len.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 10f + Vector3.up * 10f, ForceMode.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class AgentManager : MonoBehaviour
{
    public static AgentManager instance;

    public NavMeshAgent agent;
    public GameObject[] agents;
    public Animator takipciAnim;
    public Transform takipObjesi;
    public Transform dogmaObjesi;
    public bool takipBasladi;
    public GameObject takipci;

    public GameObject player;

    [Header("UI Ayarları")]
    public TMP_Text agentSayisi;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        takipciAnim.GetComponent<Animator>();
        agentSayisi.text = 1.ToString();
        takipBasladi = false;
    }

    // ------ Agent Oluşturma -------
    public void AgentOlustur(int miktar)
    {
        for (int i = 0; i < miktar; i++)
        {
            // agent oluşturuyoruz
            Instantiate(agent, dogmaObjesi.position, Quaternion.identity);

            // Oluşturduğumuz agent'ın tagı takipçiler olduğundan oluşan tüm agentleri, agents dizine atıyoruz
            player.tag = "takipciler";
            agents = GameObject.FindGameObjectsWithTag("takipciler");


            takipBasladi = true;

            // Agents dizisi boş değilse içine giriyoruz
            if (agents != null)
            {
                // agents dizisindeki her objeye a adını veriyoruz
                foreach (GameObject a in agents)
                {
                    // a'nın parantı olarak playerımızı tanımlıyoruz
                    a.transform.SetParent(player.transform);

                    // a'nın takip edeceği objeyi tanımlıyoruz
                    a.GetComponent<NavMeshAgent>().SetDestination(takipObjesi.position);

                    // a'nın animasyonunu tanımlıyoruz;
                    a.GetComponent<Animator>().Play("run");


                }

            }

        }

        

    }
    // ------ Agent Oluşturma -------

    
    // ------ Agent Yok Etme -------

    public void AgentYokEt(int miktar)
    {
        // Player controller'dan gelen yok etme rakamına göre dizi içindeki objeleri yok ediyoruz
        for (int i = 0; i < miktar; i++)
        {
            Destroy(agents[i]);
        }

        
    }

      
    // ------ Agent Yok Etme -------

    // ------ Agent Sayısı Göster -------
    public void AgentSayisiGoster()
    {
        agentSayisi.text = agents.Length.ToString();
    }
    // -------- Agent Sayısı Göster ------

    public void Update()
    {
        if(agents.Length != 0)
        {
            // agents dizisini sürekli tanımlıyoruz ki anlık sayısını bulalım
            AgentManager.instance.agents = GameObject.FindGameObjectsWithTag("takipciler");
        
            // Agent sayısı gösteriyoruz
            AgentSayisiGoster();
        }
        else
        {
            agentSayisi.text = 1.ToString();
        }


        
    }

    public void Takip()
    {
        

    }



}

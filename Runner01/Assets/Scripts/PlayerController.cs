using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float kosuHizi= 2f;
    public Animator anim;
    public Animator anim2;
    public bool sol = false;
    public bool sag = false;
    public bool started = false;
    public int miktarRakami;

    public GameObject takipci;
    public GameObject[] takipciler;

    public Transform dogmaObjesi;
    public Transform takipObjesi;

    [Header("UI Ayarları")]
    public TMP_Text agentSayisi;

    public float xLimit = 1.6f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sol = false;
        sag = false;
        started = false;
        miktarRakami = 0;
        agentSayisi.text = 1.ToString();


    }

    public void OnTriggerEnter(Collider other)
    {
        kosuHizi = 2;
        // Topla Çıkar Çarp Böl Başladı ----------

        // --------- Çarpı 2 ----------
        if (other.gameObject.name == "carpi2")
        {
            miktarRakami = 1;
            // Bir parent'ın içindeki tüm box collider'ları kapatmak için aşağıdaki kodu yazıyoruz
            foreach (var c in other.gameObject.transform.parent.GetComponentsInChildren<BoxCollider>())
            {
                c.enabled = false;
            }

            Destroy(other.transform.gameObject);

            takipciEkle();

        }
        // ------- Çarpı 2 ------------


        // --------- Artı 50 ----------

        if (other.gameObject.name == "arti50")
        {
            miktarRakami = 50;
            // Bir parent'ın içindeki tüm box collider'ları kapatmak için aşağıdaki kodu yazıyoruz
            foreach (var c in other.gameObject.transform.parent.GetComponentsInChildren<BoxCollider>())
            {
                c.enabled = false;
            }

            Destroy(other.transform.gameObject);

            takipciEkle();



        }

        // -------- Artı 50 ------------

        // --------- Artı 100 ----------

        if (other.gameObject.name == "arti100")
        {
            miktarRakami = 100;
            // Bir parent'ın içindeki tüm box collider'ları kapatmak için aşağıdaki kodu yazıyoruz
            foreach (var c in other.gameObject.transform.parent.GetComponentsInChildren<BoxCollider>())
            {
                c.enabled = false;
            }

            Destroy(other.transform.gameObject);

            takipciEkle();



        }

        // -------- Artı 100 ------------

        // --------- Artı 25 ----------

        if (other.gameObject.name == "arti25")
        {
            miktarRakami = 25;
            // Bir parent'ın içindeki tüm box collider'ları kapatmak için aşağıdaki kodu yazıyoruz
            foreach (var c in other.gameObject.transform.parent.GetComponentsInChildren<BoxCollider>())
            {
                c.enabled = false;
            }

            Destroy(other.transform.gameObject);

            takipciEkle();
        }

        // -------- Artı 25 ------------



        // --------- Eksi 50 ----------
        else if (other.gameObject.name == "eksi50")
        {
            miktarRakami = 50;
            // Bir parent'ın içindeki tüm box collider'ları kapatmak için aşağıdaki kodu yazıyoruz
            foreach (var c in other.gameObject.transform.parent.GetComponentsInChildren<BoxCollider>())
            {
                c.enabled = false;
            }

            takipciSil();

            Destroy(other.transform.gameObject);
            


        }
        // ------- Eksi 50 ------------

        // --------- Eksi 60 ----------
        else if (other.gameObject.name == "eksi60")
        {
            miktarRakami = 60;
            // Bir parent'ın içindeki tüm box collider'ları kapatmak için aşağıdaki kodu yazıyoruz
            foreach (var c in other.gameObject.transform.parent.GetComponentsInChildren<BoxCollider>())
            {
                c.enabled = false;
            }

            takipciSil();

            Destroy(other.transform.gameObject);



        }
        // ------- Eksi 60 ------------


        // Topla Çıkar Çarp Böl Bitti -----------

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            started = true;
        }

        if (started)
        {
            anim.Play("run");
            KlavyeGiris();
            transform.Translate(0, 0, kosuHizi * Time.deltaTime);
        }

        if (takipciler.Length != 0)
        {
            // takipçiler dizisini sürekli tanımlıyoruz ki anlık sayısını bulalım
            takipciler = GameObject.FindGameObjectsWithTag("takipciler");

            // takipçi sayısı gösteriyoruz
            TakipciSayisiGoster();
        }
        else
        {
            agentSayisi.text = 1.ToString();
        }

       

    }


    public void KlavyeGiris()
    {
        if (Input.GetKey(KeyCode.A))
        {
            sol = true;
            sag = false;
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            sag = true;
            sol = false;
        }

        if(sol == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-xLimit, transform.position.y, transform.position.z), kosuHizi * Time.deltaTime);
            
        }

        if(sag == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(xLimit, transform.position.y, transform.position.z), kosuHizi * Time.deltaTime);
            
        }

    }

    public void takipciEkle()
    {
        for (int i = 0; i < miktarRakami; i++)
        {
            Instantiate(takipci, new Vector3(dogmaObjesi.position.x, dogmaObjesi.position.y, dogmaObjesi.position.z), Quaternion.identity);
            
            takipciler = GameObject.FindGameObjectsWithTag("takipciler");

            foreach (GameObject t in takipciler)
            {
                t.transform.SetParent(this.transform);
                t.GetComponent<Animator>().Play("run");
            }

        }
    }

    public void takipciSil()
    {
        for (int i = 0; i < miktarRakami; i++)
        {
            Destroy(takipciler[i]);
        }
    }

    public void TakipciSayisiGoster()
    {
        agentSayisi.text = takipciler.Length.ToString();
    }


}

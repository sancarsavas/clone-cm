using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public GameObject player;
    public float mesafe = 3f;
    public float takipHizi = 4f;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z - mesafe), takipHizi * Time.deltaTime);
    }
}

using UnityEngine;
using UnityEngine.UI;

using System.Threading;

using System.Net.Sockets;

namespace UnityStandardAssets.Characters.ThirdPerson
{

public class PlayerController1 : MonoBehaviour
{
    private int frn = 0;
    public float speed;
    //public GameObject d;
   //private int humm;
   private int count;
    private Rigidbody rb;
 

    private int health;
    private Vector3 t;

    void Start()
    {
        //humm = null;
        
        rb = GetComponent<Rigidbody>();
        health = 100;
        count = 0;
        //SetCountText();
        //cropc = 0;
        t = Vector3.zero;
        //healthText.text = "";
    }
    public float timer = 0;


    void OnTriggerEnter(Collider other){
        if (other.transform.name == "ThirdPersonController") {
        //ThirdPersonUserControl humm = GetComponent<ThirdPersonUserControl>();
        //var x = other.GetComponent<ThirdPersonUserControl>();
        if (ThirdPersonUserControl.boaty) {
            print("yarghh");
        }
        }




    }
 


    void FixedUpdate()
    {
        frn += 1;
        if (frn % 1000 == 0 && count > 0){
            count -= 1;
        }

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //   movement.Set(moveHorizontal, 0f, moveVertical);
        if (ThirdPersonUserControl.boaty) {
        rb.AddForce(movement * speed);
        }
       // if (rb.transform.position.x >= 51 |
//rb.transform.position.x <= -151 | rb.transform.position.y <= -105 | rb.transform.position.z >= 201 | rb.transform.position.z <= -151) { transform.position = new Vector3(0, 2.5f, 0); }



    // if health < 0
     
        //if (count < 18)
        //{
            //timer += Time.deltaTime;

            //timerText.text = "Survived For  " + timer.ToString("F0") + " Seconds";
       // }

        //SetCountText();

    }
    /*
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup") && other.gameObject.transform.position.y > -0.18f)
        {
            t = other.gameObject.transform.position;
            other.gameObject.transform.position = new Vector3(t.x, -25f, t.z);
            // other.gameObject.SetActive(false);
            PlayerController.count += 1; // wood counter
            other.gameObject.transform.localRotation = Quaternion.Euler(0f,0f,0f);
            //other.gameObject.SetActive(false);
            count = count + 1;
            //health -= 1;
            //SetCountText();
        }
        if (other.gameObject.CompareTag("weirdblob"))
        {
            health -= 1; 
            //Random.Range(10, 25);
            other.gameObject.SetActive(false);
            SetCountText();

        }


    }


    void SetCountText()
    {

        countText.text = "Wood: " + count.ToString();
        if (count <= 0)
        {
            beamStatus.text = "Beams Are Currently : Offline...";
            lazercontrollerblock.gameObject.SetActive(false);
            twrlzr.gameObject.SetActive(false);
            twrlzr2.gameObject.SetActive(false);
        }
        if (count > 0)
        {
            beamStatus.text = "Beams Are Currently : Online";
            lazercontrollerblock.gameObject.SetActive(true);
            twrlzr.gameObject.SetActive(true);
            twrlzr2.gameObject.SetActive(true);
        }
               healthText.text = "crop = " + cropc;
       

           
        
    }
*/



}


}
using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;
using System.Collections.Generic;

/*
collect sticks/fibre on collision, fibre growth mechanic? or not bother? stick respawn rate.
purposefully slow start? animate inanimate objects after insanity bar goes too high? ui ui ui
pirhanas. 


*/
namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        public static bool boaty = false;
        public static bool boaty2 = false;
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
        public GameObject rafty;
        public GameObject watery;
        public GameObject plyr;
        private bool woody = false;

        //public GameObject btsd;
        public static int playerStickCount = 0;
        public static int playerStringCount = 0;
        public static int playerHealth = 100;

        private void Start()
        {
            rafty = GameObject.Find("raft1");
            watery = GameObject.Find("WaterProDaytime");
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
            if (Input.GetButtonDown("Action")) {
                if (boaty) {boaty2 = true;} else { print("dismounting"); boaty = false ; transform.position = new Vector3( rafty.transform.position.x + 19, rafty.transform.position.y, rafty.transform.position.z + 19);}
            


            }
        }





        public void SetParent(GameObject newParent) {

            rafty.transform.parent = newParent.transform;

        }
        public void DetatchFromParent(){
            transform.parent = null;
        }



        void OnTriggerExit(Collider other) {
            print("left the collider " + other.transform.name);
            if (other.transform.name == "WaterProDaytime"){

            watery.transform.position = new Vector3(transform.position.x, watery.transform.position.y, transform.position.z);
        }
            if (other.transform.name == "raft1"){
                boaty = false;
                boaty2 = false;
                plyr.GetComponent<Rigidbody>().useGravity = true;
                //DetatchFromParent();

            }
            if (other.transform.name == "stick") {
                other.transform.position = new Vector3();
            }
            if (other.transform.name == "WaterProDaytime") {woody = false; print("water exit");}

        }

        void OnTriggerEnter(Collider collisioninfo) {
            if (collisioninfo.transform.name == "raft1"){
                boaty = true;
                print("boaty");
                //transform.position = new Vector3(rafty.transform.position.x, rafty.transform.position.y, rafty.transform.position.z);
                

                //SetParent(plyr);
            }
            
            if (collisioninfo.transform.name == "WaterProDaytime") { woody = true; print("waterhit");}
            if (collisioninfo.transform.name == "fibre1") {collisioninfo.transform.position = new Vector3(collisioninfo.transform.position.x, collisioninfo.transform.position.y - 8, collisioninfo.transform.position.z);
                playerStringCount += 5; print(playerStringCount);}
            if (collisioninfo.transform.name == "stick") {collisioninfo.transform.position = new Vector3(collisioninfo.transform.position.x, collisioninfo.transform.position.y - 4, collisioninfo.transform.position.z);
                playerStickCount += 1;
                }
        }



        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            // read inputs
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C);


            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v*m_CamForward + h*m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v*Vector3.forward + h*Vector3.right;
            }
#if !MOBILE_INPUT
			// walk speed multiplier
	        if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script

            
            if (!boaty2) {
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
            } else {plyr.GetComponent<Rigidbody>().useGravity = false; transform.position = new Vector3(rafty.transform.position.x, rafty.transform.position.y, rafty.transform.position.z);}
            //if (boaty) {rafty.transform.position = new Vector3(plyr.transform.position.x, plyr.transform.position.y, plyr.transform.position.z);}
            
        

        }
    }
}

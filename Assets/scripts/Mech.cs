using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : MonoBehaviour
{
    public GameObject Wheel_1;
    public GameObject Wheel_2;
    public GameObject Wheel_3;
    public GameObject SpaceGunImage;

    public GameObject Mech_1;
    public GameObject Mech_2;
    public GameObject Mech_3;
    public GameObject SpaceGunItem;
    public GameObject SpaceGun;

    public GameObject Exit;
    public GameObject Door;

    public AudioSource PickUp;
    public AudioSource GunPick;



    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Wheel_1"))
        {
            Mech_1.SetActive(false);
            Wheel_1.SetActive(true);
            PickUp.Play();
        }

        if (other.CompareTag("Wheel_2"))
        {
            Mech_2.SetActive(false);
            Wheel_2.SetActive(true);
            Exit.SetActive(true);
            Door.SetActive(false);
            PickUp.Play();
        }

        if (other.CompareTag("Wheel_3"))
        {
            Mech_3.SetActive(false);
            Wheel_3.SetActive(true);
            Exit.SetActive(true);
            PickUp.Play();

        }
        if (other.CompareTag("SpaceGunItem"))
        {

            SpaceGunItem.SetActive(false);
            SpaceGun.SetActive(true);
            SpaceGunImage.SetActive(true);
            GunPick.Play();
        }
    }
}

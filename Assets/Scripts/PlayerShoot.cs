using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectil;
    public float speed = 100f;

    public float fireRate;

    private float nextFire;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bu = Instantiate(projectil, transform.position, transform.rotation);
            Rigidbody rb = bu.GetComponent<Rigidbody>();
            rb.AddForce(bu.transform.forward * speed, ForceMode.Impulse);
            audioSource.Play();
        }
    }

    public void ChangeProjectile(GameObject waffe)
    {
        projectil = waffe;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    public GameObject shot; //子弹
    public Transform shotSpawn; //子弹发射位置
    public float delay; //发射子弹的延迟
    public float fireRate;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Fire", delay, fireRate);
	}
	void Fire () {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        GetComponent<AudioSource>().Play();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float sensitivity;
    private float verAim;
    private float horAim;
    public float coolDown;
    public float coolDownMissiles;
    private float nextMissile;
    private float nextShot;
    private float nextMove;
    public float nextRound;
    private bool laser = true;
    private bool machineGun = false;
    private bool missiles = false;
    public float muzzleVelocity;
    public bool laserFire = false;
    public GameObject muzzleFlash;
    public GameObject round;
    private GameObject flashLeft;
    private GameObject flashRight;
    public int shots;
    private Vector3 muzzlePositionLeft;
    private Vector3 muzzlePositionRight;
    private GameObject gunLeft;
    private GameObject gunRight;
    private GameObject weaponSystem;
    private Transform aim;
    public GameObject barrage;
    public float thrust;
    public AudioSource gunSound;
    public AudioSource laserSound;

    private void Start()
    {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {

        Rigidbody player = GetComponent<Rigidbody>();
        aim = GetComponent<Transform>();
        weaponSystem = GameObject.FindGameObjectWithTag("WeaponSystem");
        gunLeft = GameObject.FindGameObjectWithTag("GunLeft");
        gunRight = GameObject.FindGameObjectWithTag("GunRight");
        muzzlePositionLeft = gunLeft.transform.position + gunLeft.transform.forward * 0.7f + gunLeft.transform.up * 0.14f;
        muzzlePositionRight = gunRight.transform.position + gunRight.transform.forward * 0.7f + gunRight.transform.up * 0.14f;


        horAim += Input.GetAxis("Mouse X") * sensitivity;
        verAim += Input.GetAxis("Mouse Y") * -sensitivity;

        transform.eulerAngles = new Vector3(Mathf.Clamp(verAim, -85, 45), horAim, 0);

        if (Input.GetMouseButtonDown(0) && laser) { laserFire = true; ; laserSound.Play(); }
        if ((Input.GetMouseButtonUp(0) && laser) || (!laser && laserFire)) { laserFire = false; laserSound.Stop(); }


        if (Input.GetMouseButtonDown(0) && nextShot < Time.time && machineGun)
        {
            nextShot = Time.time + coolDown;

            flashLeft = Instantiate(muzzleFlash, muzzlePositionLeft, gunLeft.transform.rotation);
            flashRight = Instantiate(muzzleFlash, muzzlePositionRight, gunRight.transform.rotation);

            flashLeft.transform.SetParent(weaponSystem.transform);
            flashRight.transform.SetParent(weaponSystem.transform);

            StartCoroutine(BurstFire());

        }

        if (Input.GetMouseButton(0) && missiles && nextMissile < Time.time)
        {

            nextMissile = Time.time + coolDownMissiles;

            GameObject Barage = Instantiate(barrage, player.position + player.transform.forward * 0.8f, player.rotation);
            Rigidbody BarageRB = Barage.GetComponent<Rigidbody>();
            BarageRB.AddForce(transform.forward * thrust * Time.deltaTime);

        }

        if (Input.GetKeyDown("space") && laser && nextMove <= Time.time)
        {

            nextMove = Time.time + coolDown;
            laser = false;
            machineGun = true;
            weaponSystem.transform.position += weaponSystem.transform.up;

        }

        if (Input.GetKeyDown("space") && machineGun && nextMove <= Time.time)
        {

            nextMove = Time.time + coolDown;
            missiles = true;
            machineGun = false;
            weaponSystem.transform.position += weaponSystem.transform.up;

        }

        if (Input.GetKeyDown("space") && missiles && nextMove <= Time.time)
        {

            nextMove = Time.time + coolDown;
            laser = true;
            missiles = false;
            weaponSystem.transform.position -= weaponSystem.transform.up * 2;

        }

        if (Input.GetKeyDown("r")) 
        {
            SceneManager.LoadScene(1);

            }

        if (Input.GetKeyDown("q")) { SceneManager.LoadScene(0); }

    }

    IEnumerator BurstFire() {

        nextMove = Time.time + 1.8f;

        gunSound.Play();

        for (int i = 0; i <= shots; i++)
        {

            GameObject roundLeft = Instantiate(round, muzzlePositionLeft + gunLeft.transform.forward * 1.0f, gunLeft.transform.rotation);
            GameObject roundRight = Instantiate(round, muzzlePositionRight + gunRight.transform.forward * 1.0f, gunRight.transform.rotation);

            Rigidbody roundLeftRB = roundLeft.GetComponent<Rigidbody>();
            Rigidbody roundRightRB = roundRight.GetComponent<Rigidbody>();

            roundLeftRB.velocity = aim.forward * muzzleVelocity;
            roundRightRB.velocity = aim.forward * muzzleVelocity;

            yield return new WaitForSeconds(nextRound);

        }

        gunSound.Stop();

    }
}
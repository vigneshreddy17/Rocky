using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public static PlayerControl instance;

    public float playerSpeed;
    private Vector2 playerMoveInput;
    private Camera cam;

    public Transform gunMovement;
    public Transform handMovement;

    public Animator animator;

    public GameObject bulletToFire;
    public Transform firePoint;

    public float timeBWShots;
    private float shotCount;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        playerMoveInput.x = Input.GetAxisRaw("Horizontal");
        playerMoveInput.y = Input.GetAxisRaw("Vertical");

        playerMoveInput.Normalize();

        transform.position += new Vector3(playerMoveInput.x * Time.deltaTime * playerSpeed, playerMoveInput.y * Time.deltaTime * playerSpeed, 0f);
        Vector3 mouseMovement = Input.mousePosition;
        Vector3 screenPoint = cam.WorldToScreenPoint(transform.localPosition);

        if (mouseMovement.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            gunMovement.localScale = new Vector3(-0.1586463f, -0.1586463f, 0.1586463f);
        }
        else
        {
            transform.localScale = Vector3.one;
            gunMovement.localScale = new Vector3(0.1586463f, 0.1586463f, 0.1586463f);
        }


        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
            shotCount = timeBWShots;
        }

        if (Input.GetMouseButton(0))
        {
            shotCount = shotCount - Time.deltaTime;

            if (shotCount <= 0)
            {
                Instantiate(bulletToFire, firePoint.position, firePoint.rotation);

                shotCount = timeBWShots;
            }
        }

            

        Vector2 offSet = new Vector2(mouseMovement.x - screenPoint.x, mouseMovement.y - screenPoint.y);
        float angle = Mathf.Atan2(offSet.y,offSet.x) * Mathf.Rad2Deg;//returns the slope
        gunMovement.rotation = Quaternion.Euler(0, 0, angle);
        handMovement.rotation = Quaternion.Euler(0, 0, angle);

        if (playerMoveInput != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
            animator.SetBool("isMoving", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bow : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject arrowPrefab;
    private Vector2 aimDirection = Vector2.right;
    private float shootCooldown = .5f;
    public float shootTimer;
    public Animator anim;
    public PlayerMovement playerMovement;

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;
        HandleAniming();
        if (Input.GetButtonDown("Shoot") && shootTimer <= 0)
        {
            playerMovement.isShooting = true;
            anim.SetBool("isShooting", true);
        }
    }

    public void shoot()
    {
        if (shootTimer <= 0)
        {
            Arrow arrow = Instantiate(arrowPrefab, launchPoint.position, Quaternion.identity).GetComponent<Arrow>();
            arrow.direction = aimDirection;
            shootTimer = shootCooldown;
            anim.SetBool("isShooting", false);
            playerMovement.isShooting = false;
        }
    }

    private void OnEnable()
    {
        anim.SetLayerWeight(0, 0);
        anim.SetLayerWeight(1, 1);
    }
    private void OnDisable()
    {
        anim.SetLayerWeight(0, 1);
        anim.SetLayerWeight(1, 0);
    }
    private void HandleAniming()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if(horizontal != 0 ||vertical != 0)
        {
            aimDirection = new Vector2(horizontal, vertical).normalized;
            anim.SetFloat("aimX", aimDirection.x);
            anim.SetFloat("aimY", aimDirection.y);
        }
    }
}

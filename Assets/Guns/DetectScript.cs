using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DetectScript : MonoBehaviour
{
    bool detected;
    GameObject target;
    public Transform enemyy;
    public Animator animator;
    public GameObject bullet;
    public Transform shootPoint;
    public float chaseSpeed = 5f;
    public float shootSpeed = 10f;
    public float timeToShoot = 1.3f;
    float originalTime;

    public NavMeshAgent enemy;
    public Transform Player;
    

    // Start is called before the first frame update
   
    
    
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        originalTime = timeToShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if (detected) 
        {
            animator.SetBool("isRunning", true);
            enemy.speed = chaseSpeed;
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        if (detected)
        {
            enemyy.LookAt(target.transform);
            enemy.SetDestination(Player.position);
        }
    }

    private void FixedUpdate()
    {
        if (detected)
        {
            timeToShoot -= Time.deltaTime;


            if (timeToShoot < 0)
            {
                ShootPlayer();
                timeToShoot = originalTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            detected = true;
            target = other.gameObject;
        }
    }

    private void ShootPlayer()
    {
        GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody rig = currentBullet.GetComponent<Rigidbody>();
        Destroy(currentBullet, 1f);
        rig.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
    }
}

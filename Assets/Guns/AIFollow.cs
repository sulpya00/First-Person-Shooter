using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIFollow : MonoBehaviour
{
    // What game objects are what
    public Animator animator;
    public NavMeshAgent enemy;
    public Transform Player;

    public int followMe = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set monster to player destination
        if (Input.GetKey(KeyCode.E))
            followMe = 1;

        if (followMe == 1)
        {
            animator.SetBool("isRunning", true);

            enemy.SetDestination(Player.position);
        }
    }
}
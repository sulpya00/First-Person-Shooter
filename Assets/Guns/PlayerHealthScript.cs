using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthScript : MonoBehaviour
{
    public Text healthDisplay;

    public float health = 100f;

    void Update()
    {
        healthDisplay.text = health.ToString();
        Debug.Log(health);
        if (health <= 0f)
        {
            Die();
        }
    }

    void OnCollisionEnter(Collision Other)
    {
        if(Other.gameObject.tag == "Bullet")
        {
            health = health - 10;
        }
    }

    void Die()
    {
        SceneManager.LoadScene("DeathScene");
    }
}

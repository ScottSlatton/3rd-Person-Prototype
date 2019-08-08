using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public CapsuleCollider playerCollider;
    public float moveSpeed = 5f;

    private GameObject enemy;
    private Enemy enemyScript;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = this.GetComponent<CapsuleCollider>();
        playerCollider.height = 1f;
        playerCollider.center = new Vector3(0f,-.5f,0f);

        enemy = GameObject.Find("Battle_Dummy");
        enemyScript = enemy.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveJump = Input.GetAxis("Jump");

        Vector3 movement = new Vector3(moveHorizontal, moveJump, moveVertical);


        // moves the player character
        transform.Translate(movement * Time.deltaTime * moveSpeed);


        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            enemyScript.enemyHealth--;
            print(enemyScript.enemyHealth);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyScript.enemyHealth -= 5;
            print(enemyScript.enemyHealth);
        }
    }
}

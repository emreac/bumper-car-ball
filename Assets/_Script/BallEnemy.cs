using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallEnemy : MonoBehaviour
{
    GameObject goalText;
    [SerializeField] float speed;
    Rigidbody enemyBallRb;
    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        enemyBallRb = GetComponent<Rigidbody>();
        ball = GameObject.Find("BallTarget");
        goalText = GameObject.Find("GoalText");


        if (goalText != null)
        {
            goalText.SetActive(false); // Ensure it starts hidden
        }
        else
        {
            Debug.LogError("GoalText object not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (ball.transform.position - transform.position).normalized;
        enemyBallRb.AddForce(lookDirection * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoalTrigger"))
        {
            goalText.SetActive(true);
            StartCoroutine(WaitAfterGoal());
        }
    }

    IEnumerator WaitAfterGoal()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

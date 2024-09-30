using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallEnemy : MonoBehaviour
{
    public ScoreManager scoreManager;

    //GameObject goalText;
    [SerializeField] float speed;
    Rigidbody enemyBallRb;
    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        enemyBallRb = GetComponent<Rigidbody>();
        ball = GameObject.Find("GoalTrigger1");
        //goalText = GameObject.Find("GoalText");

        /*
        if (goalText != null)
        {
            goalText.SetActive(false); // Ensure it starts hidden
        }
        else
        {
            Debug.LogError("GoalText object not found!");
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (ball.transform.position - transform.position).normalized;
        enemyBallRb.AddForce(lookDirection * speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoalTrigger2"))
        {
            DOTween.Restart("GoalText");
           // goalText.SetActive(true);
            scoreManager.Player1Scored();
            
        }

        if (other.gameObject.CompareTag("GoalTrigger1"))
        {
            DOTween.Restart("GoalText");
            //goalText.SetActive(true);
            scoreManager.Player2Scored();
           
        }
    }

    IEnumerator WaitAfterGoal()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

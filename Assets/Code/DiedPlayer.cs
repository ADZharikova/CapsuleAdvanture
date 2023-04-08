using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiedPlayer : MonoBehaviour
{
    private bool _isDied = false;

    private void FixedUpdate()
    {
        if (_isDied)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            _isDied = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Died")
        {
            _isDied = true;
            Debug.Log("Touch");
        }
    }
}

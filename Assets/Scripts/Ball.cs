using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D hook;
    public GameObject nextball;

    private bool isPressed = false;
    public float releaseTime = 0.15f;
    public float maxDistance = 2f;


    private void Update()
    {
        if(isPressed)
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(Vector3.Distance(mousepos,hook.position) > maxDistance)
                {
                rb.position = hook.position + (mousepos - hook.position).normalized * maxDistance;
                }
            else
                rb.position = mousepos;
        }
    }
    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(2f);
        if(nextball != null)
        {
            nextball.SetActive(true);
        }
        else
        {
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}

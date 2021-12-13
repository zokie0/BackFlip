using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control2 : MonoBehaviour
{
    public GameObject player;
    public GameObject Floor;
    public GameObject destroyZone;
    public GameObject Up;
    public GameObject OW;
    public float height;
    public float hThresh = 0;
    public bool started = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) & started == false) //code ran when gameplay starts
        {
            started = true;
            StartCoroutine(SummonUp());
            StartCoroutine(SummonOW());
        }

    }

    private IEnumerator SummonUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.8f, 1.5f));
            if (Random.value > 0.5f)//start low move up
            {
                Instantiate(Up, new Vector2(Random.Range(-2.0f, 2.0f), -6), Quaternion.identity);
            }
            else //start high move down
            {
                GameObject newUp = Instantiate(Up, new Vector2(Random.Range(-2.0f, 2.0f), 6), Quaternion.identity);
                newUp.GetComponent<Move>().speed = newUp.GetComponent<Move>().speed * -1;
            }
        }
    }
    private IEnumerator SummonOW()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2.0f, 3.0f));
            if (Random.value > 0.5f)//start low move up
            {
                Instantiate(OW, new Vector2(Random.Range(-2.0f, 2.0f), -6), Quaternion.identity);
            }
            else //start high move down
            {
                GameObject newUp = Instantiate(OW, new Vector2(Random.Range(-2.0f, 2.0f), 6), Quaternion.identity);
                newUp.GetComponent<Move>().speed = newUp.GetComponent<Move>().speed * -1;
            }
            //Instantiate(OW, new Vector2(Random.Range(-2.0f, 2.0f), 6), Quaternion.identity);
        }
    }
}

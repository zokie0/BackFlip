using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public GameObject player;
    public GameObject Floor;
    public GameObject destroyZone;
    public GameObject Up;
    public GameObject OW;
    public Text heightT;
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
        if (player.GetComponent<Rigidbody2D>().simulated == true & started == false) //code ran when gameplay starts
        {
            started = true;
            StartCoroutine(SummonUp());
            StartCoroutine(SummonOW());
        }

        if (height > hThresh + 3) //summon based on height
        {
            Instantiate(Up, new Vector2(Random.Range(-2.0f, 2.0f), player.transform.position.y + Random.Range(5.5f, 7.0f)), Quaternion.identity);
            Instantiate(OW, new Vector2(Random.Range(-2.0f, 2.0f), player.transform.position.y + 6), Quaternion.identity);  
            hThresh = height;
        }



        this.transform.position = new Vector3(0, player.transform.position.y, -10); // cam follows player vertically

        if (player.transform.position.y > height) { height = player.transform.position.y; } //height logic
        heightT.text = "" + Mathf.Round(height * 100); //text update

        Floor.transform.position = new Vector2(0, height - 5.2f); //move floor
        destroyZone.transform.position = new Vector2(0, height - 15.0f); //move destroyZone
    }

    private IEnumerator SummonUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.8f, 1.5f));
            Instantiate(Up, new Vector2(Random.Range(-2.0f, 2.0f), player.transform.position.y + 6), Quaternion.identity);
        }
    }
    private IEnumerator SummonOW()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(4, 5));
            Instantiate(OW, new Vector2(Random.Range(-2.0f, 2.0f), player.transform.position.y + 6), Quaternion.identity);
        }
    }
}

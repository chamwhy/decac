using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject player;
    public Camera cam;
    public GameObject touchPanel;

    public float smashForce = 6f;
    private bool playerFollow = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (playerFollow)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, -10);
            touchPanel.transform.position = new Vector3(0, player.transform.position.y, 0);
        }
    }

    public void FollowBool(bool isFollow)
    {
        playerFollow = isFollow;
    }

    public void MoveEffect(int force)
    {
        if (gameManager.isStart)
        {
            StartCoroutine("addForce", force);
        }
    }

    IEnumerator AddForce(int force)
    {
        transform.Translate(Vector3.up * force * smashForce);
        for(int i = 0; i < smashForce; i++)
        {
            transform.Translate(Vector3.down * force);
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void CloseUp()
    {
        StartCoroutine("Close");
    }

    IEnumerator Close()
    {
        int which = (player.transform.position.x > 0) ? 1 : -1;
        while(cam.orthographicSize > 3.05f)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.5f);
            cam.orthographicSize = (cam.orthographicSize - 3) * 0.6f + 3;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -20 * which), 0.5f);
            yield return new WaitForSeconds(0.02f);
        }
    }

}

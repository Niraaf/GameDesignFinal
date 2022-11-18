using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverText : MonoBehaviour
{
    public GameObject player;
    float offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position.x - player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + offset, player.transform.position.y + 4.5F, 2F);
    }
}

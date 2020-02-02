using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform m_player;
    //private float m_initialY;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = m_player.transform.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        //roatteion of camera same as player rotation but it is not needed for me.
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, m_player.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollowingUI : MonoBehaviour
{
    public Transform trs_followingObject;
    public Vector3 vec_offset;
    public bool b_isFollowing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(b_isFollowing)
        transform.position = Camera.main.WorldToScreenPoint(trs_followingObject.position + vec_offset);
    }
}

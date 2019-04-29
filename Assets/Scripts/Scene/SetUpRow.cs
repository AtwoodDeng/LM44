using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SetUpRow : MonoBehaviour
{
    public GameObject prefab;
    public float totalDuration = 45f;
    public int totalNumber = 10;

    public void Start()
    {
        SetUp();
    }

    public void SetUp()
    {
        for( int i = 0 ; i < totalNumber ; ++ i )
            SetUpTime( totalDuration / totalNumber * i  );
    }

    public void SetUpTime(float time)
    {
        var obj = Instantiate(prefab) as GameObject;
        obj.gameObject.SetActive(true);
        obj.transform.position = prefab.transform.position;
        obj.transform.rotation = prefab.transform.rotation;
        var director = obj.GetComponent<PlayableDirector>();
        director.initialTime = time;
        director.Play();
    }

}



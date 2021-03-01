using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPath : MonoBehaviour
{
    public GameObject target;
    public string path;
    public float time = 30.0f;

    void Start()
    {
        iTween.MoveTo(target, iTween.Hash("path", iTweenPath.GetPath(path), "time", time, "easeType", iTween.EaseType.easeInOutSine));
    }
}

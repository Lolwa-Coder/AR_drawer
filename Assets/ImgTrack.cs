using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImgTrack : MonoBehaviour
{

    private ARTrackedImageManager _imageManager;



    private void Awake()
    {
        _imageManager = FindObjectOfType<ARTrackedImageManager>();
    }
    public void onEnable()
    {
        _imageManager.trackedImagesChanged += OnTrackedImageChanged;
    }
   
    public void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var VARIABLE in args.added)
        {
            Debug.Log(VARIABLE.name);
        }

    }
    // Start is called before the first frame update
   
}

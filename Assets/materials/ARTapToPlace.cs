using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.IO;


[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlace : MonoBehaviour
{
    public GameObject gameObjectToInstantiate;

    private GameObject spawnObject;
    private ARRaycastManager _raycastManager;
    private Vector2 touchPosition;
    static List<ARRaycastHit> hits=new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Awake()
    {
        _raycastManager= GetComponent<ARRaycastManager>();

    }
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount>0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
      
        }
        touchPosition= default;
        return false;
    }
     public static void WriteString(string texttt )
   {
       
        
       string path =Application.persistentDataPath+$"/ARMODEL.txt";
       //Write some text to the test.txt file
       StreamWriter writer = new StreamWriter(path, true);
       writer.WriteLine(texttt);
        writer.Close();
       StreamReader reader = new StreamReader(path); 
       //Print the text from the file
       Debug.Log(reader.ReadToEnd());
       reader.Close();
    }
    // Update is called once per frame
    void Update()
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }
        if(_raycastManager.Raycast(touchPosition,hits,TrackableType.PlaneWithinPolygon))
        {
            var hitpose= hits[0].pose;
            
            spawnObject=Instantiate(gameObjectToInstantiate, hitpose.position, hitpose.rotation);
            var stt= hitpose.position.x.ToString()+ " ";
            var stt2=hitpose.position.y.ToString()+ " ";
            var stts=hitpose.position.z.ToString()+ " ";
            //hitpose.rotation.ToString();
            var stt3=stt+stt2;
            var stt4=stt3+stts;
            var stt5=hitpose.rotation.ToString();
            
            WriteString(stt4+stt5);
            
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;

public class TestEyeTracking : MonoBehaviour
{
    List<Vector3> ListPos = new List<Vector3>();
    LineRenderer Trait;
    Camera cam;

    int freq = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Trait = cam.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Get eye tracking data in world space
        var eyeTrackingData = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World);

        // Check if gaze ray is valid
        if (eyeTrackingData.GazeRay.IsValid)
        {
            
            // The origin of the gaze ray is a 3D point
            var rayOrigin = eyeTrackingData.GazeRay.Origin;

            // The direction of the gaze ray is a normalized direction vector
            var rayDirection = eyeTrackingData.GazeRay.Direction;

            Vector3 origine = rayOrigin;
            Vector3 fin = rayOrigin + rayDirection * 10f;

            Trait.SetPosition(0, origine);
            Trait.SetPosition(1, fin);

            // Debug.DrawLine(rayOrigin, rayOrigin + rayDirection * 10f);

            #region Test Rendu Chemin du regard
            // On affiche les coordonnées de Eye-tracking
            // Debug.Log("Origine : " + rayOrigin);
            // Debug.Log("Direction : " + rayDirection);
            // freq += 1;
            // ListPos.Add(rayOrigin + rayDirection * 10.0f);
            //if (freq == 10)
            //{
            //    DrawLine();
            //    freq = 0;
            //}
            #endregion
        }
    }

    void DrawLine()
    {
        Trait.positionCount = ListPos.Count;
        for (int i=0; i<ListPos.Count; i++)
        {
            Trait.SetPosition(i, ListPos[i]);
        }
    }
}

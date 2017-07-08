using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSController : MonoBehaviour {

    public static GPSController Instance { set; get; } //?
    public float latitude;
    public float longitude;

    private void FixedUpdate() // Change Start to Update if you want to get this every frame or try something else
    {
        Instance = this;
        DontDestroyOnLoad(gameObject); //doesn't destroy when changin scenes
        StartCoroutine(StartLocationService());


    }

    private IEnumerator StartLocationService()
    {
        if(!Input.location.isEnabledByUser)
        {   
            Debug.Log("User has no permission");
            latitude += 1; // just to test update on laptop
            longitude += 1; // just to test update on laptop
            yield break;
        }

        Input.location.Start();
        int maxWait = 20; // attempts

        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0) // if there is a bug with it.
        {
            Debug.Log("Timed Out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("unable to get location");
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;

        yield break;

    }
}

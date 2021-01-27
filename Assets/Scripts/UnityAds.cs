using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
[RequireComponent (typeof (Button))]
public class UnityAds : MonoBehaviour, IUnityAdsListener
{
    string gameId = "3591244";
    public string myPlacementId = "RestartGame";
    public bool testMode = true;

    public GameObject on;
    public GameObject off;

    // Initialize the Ads listener and service:
    void Start () {
        Advertisement.AddListener (this);
        Advertisement.Initialize (gameId, testMode);
        /*myButton = GetComponent <Button> ();

        // Set interactivity to be dependent on the Placement’s status:
        myButton.interactable = Advertisement.IsReady (myPlacementId); 

        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener (ShowRewardedVideo);

        // Initialize the Ads listener and service:
        Advertisement.AddListener (this);
        Advertisement.Initialize (gameId, true);*/
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) 
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished) 
        {
            
        } 
        else if (showResult == ShowResult.Skipped) 
        {
            
        } 
        else if (showResult == ShowResult.Failed) 
        {
            
        }
    }

    public void OnUnityAdsDidError (string message) 
    {
        Debug.Log("Deu errou");
    }

    public void OnUnityAdsDidStart (string placementId) 
    {
        Debug.Log("Rodou AD");
    } 
}
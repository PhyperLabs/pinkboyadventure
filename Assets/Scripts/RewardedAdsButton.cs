using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

[RequireComponent (typeof (Button))]
public class RewardedAdsButton : MonoBehaviour, IUnityAdsListener 
{

    #if UNITY_IOS
    private string gameId = "3591245";
    #elif UNITY_ANDROID
    private string gameId = "3591244";
    #endif

    Button myButton;
    public string myPlacementId = "RestartGame";
    private bool isTest = false;
    void Start () 
    {   
        myButton = GetComponent <Button> ();

        // Set interactivity to be dependent on the Placement’s status:
        myButton.interactable = Advertisement.IsReady (myPlacementId); 

        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener (ShowRewardedVideo);

        // Initialize the Ads listener and service:
        Advertisement.AddListener (this);
        Advertisement.Initialize (gameId, isTest);
    }

    // Implement a function for showing a rewarded video ad:
    void ShowRewardedVideo () 
    {
        Advertisement.Show (myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady (string placementId) 
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId) {        
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) 
    {
        // Define conditional logic for each ad completion status:
        switch (showResult)
        {
            case ShowResult.Finished:
            Controller.instance.RestartGame();
            Debug.Log("Assistiu AD");
            break;
            case ShowResult.Skipped:
            Debug.Log("Não Viram o AD");
            break;
            case ShowResult.Failed:
            Debug.LogWarning ("Deu Errado Bolado");
            break;
        }
    }

    public void OnUnityAdsDidError (string message) 
    {
        // Log the error.
        Debug.Log("Deu errou");
    }

    public void OnUnityAdsDidStart (string placementId) 
    {
        // Optional actions to take when the end-users triggers an ad.
        Debug.Log("Rodou AD");
    } 
}
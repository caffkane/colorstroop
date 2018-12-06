using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RateButton : MonoBehaviour
{
	//  The button to rate. Assigned from inspector.
	public Button btnRate;

	public string PlayStoreURL = "https://play.google.com/store/apps/details?id=com.rabbiteargames.colorstroop";

	public string AmazonStoreURL = "https://play.google.com/store/apps/details?id=com.rabbiteargames.colorstroop";

	public string AppStoreURL = "https://itunes.apple.com/app/id1442036674";

	bool isAmazon = false;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		btnRate.onClick.AddListener(() =>
		                             {
			if (InputManager.instance.canInput ()) {
				InputManager.instance.DisableTouchForDelay ();
				InputManager.instance.AddButtonTouchEffect ();

				#if UNITY_ANDROID
				if(!isAmazon) {
                    Application.OpenURL(AmazonStoreURL);
				}
				else {
                    Application.OpenURL(PlayStoreURL);
				}
				#elif UNITY_IOS
				Application.OpenURL(AppStoreURL);
				#elif UNITY_EDITOR
				Application.OpenURL("https://rabbiteargames.com/");
				#endif
			}
		});
	}
}

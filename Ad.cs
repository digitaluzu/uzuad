using UnityEngine;
using System.Collections;

namespace Uzu
{
	public static class Ad
	{
		public static int INVALID_BANNER_ID = -1;

		public static void Init (string adUnitId)
		{
#if UZU_GOOGLEPLAY
			AndroidAdMobController.instance.Init (adUnitId);
#endif
		}

		public static int CreateBanner (TextAnchor textAnchor)
		{
#if UNITY_IOS
			iAdBanner banner = iAdBannerController.instance.CreateAdBanner (textAnchor);
			if (banner != null) {
				return banner.id;
			}
#elif UZU_GOOGLEPLAY
			GoogleMobileAdBanner banner = AndroidAdMobController.instance.CreateAdBanner (textAnchor, GADBannerSize.SMART_BANNER);
			if (banner != null) {
				return banner.id;
			}
#endif

			return INVALID_BANNER_ID;
		}

		public static void ShowBanner (int bannerId)
		{
#if UNITY_IOS
			iAdBanner banner = iAdBannerController.instance.GetBanner (bannerId);
			if (banner == null) {
				Debug.LogWarning ("Invalid banner id: " + bannerId);
				return;
			}

			banner.Show ();
#elif UZU_GOOGLEPLAY
			GoogleMobileAdBanner banner = AndroidAdMobController.instance.GetBanner (bannerId);
			if (banner == null) {
				Debug.LogWarning ("Invalid banner id: " + bannerId);
				return;
			}

			banner.Show ();
#endif
		}

		public static void HideBanner (int bannerId)
		{
#if UNITY_IOS
			iAdBanner banner = iAdBannerController.instance.GetBanner (bannerId);
			if (banner == null) {
				Debug.LogWarning ("Invalid banner id: " + bannerId);
				return;
			}

			banner.Hide ();
#elif UZU_GOOGLEPLAY
			GoogleMobileAdBanner banner = AndroidAdMobController.instance.GetBanner (bannerId);
			if (banner == null) {
				Debug.LogWarning ("Invalid banner id: " + bannerId);
				return;
			}

			banner.Hide ();
#endif
		}

		public static void DestroyBanner (int bannerId)
		{
#if UNITY_IOS
			iAdBannerController.instance.DestroyBanner (bannerId);
#elif UZU_GOOGLEPLAY
			AndroidAdMobController.instance.DestroyBanner (bannerId);
#endif
		}
	}
}

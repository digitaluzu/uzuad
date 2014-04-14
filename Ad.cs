using UnityEngine;
using System.Collections;

namespace Uzu
{
  public static class Ad
  {
    public static int CreateBanner (TextAnchor textAnchor)
    {
#if UNITY_IOS
      iAdBanner banner = iAdBannerController.instance.CreateAdBanner (textAnchor);
      return banner.id;
#endif
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
#endif
    }

    public static void DestroyBanner (int bannerId)
    {
#if UNITY_IOS
      iAdBannerController.instance.DestroyBanner (bannerId);
#endif
    }
  }
}

using System.Web;
using System.Web.Optimization;

namespace EddyNewHome
{
    public class BundleConfig
    {
        // 묶음에 대한 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=301862를 참조하세요.
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region 원본 스크립트 및 CSS
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            // Modernizr의 개발 버전을 사용하여 개발하고 배우십시오. 그런 다음
            // 프로덕션에 사용할 준비를 하고 https://modernizr.com의 빌드 도구를 사용하여 필요한 테스트만 선택하세요.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            #endregion

            #region Samuel Anderson Template style 스크립트 및 CSS
            bundles.Add(new StyleBundle("~/eddyhome/css").Include(
                "~/assets/vendor/bootstrap/css/bootstrap.min.css",
                "~/assets/vendor/fontawesome/css/font-awesome.min.css",
                "~/assets/vendor/flaticons/flaticon.css",
                "~/assets/vendor/hover/css/hover-min.css",
                "~/assets/vendor/wow/animate.css",
                "~/assets/vendor/mfp/css/magnific-popup.css",
                "~/assets/vendor/footable/footable.core.css", // 200813 페이저영역 플러그인 추가
                "~/assets/custom/css/style.css"));

            bundles.Add(new ScriptBundle("~/eddyhome/js").Include(
                "~/assets/vendor/jquery/js/jquery-2.2.0.min.js",
                "~/assets/vendor/bootstrap/js/bootstrap.min.js",
                "~/assets/vendor/imagesloaded/js/imagesloaded.pkgd.min.js",
                "~/assets/vendor/isotope/js/isotope.pkgd.min.js",
                "~/assets/vendor/mfp/js/jquery.magnific-popup.min.js",
                "~/assets/vendor/circle-progress/circle-progress.js",
                "~/assets/vendor/waypoints/waypoints.min.js",
                "~/assets/vendor/anicounter/jquery.counterup.min.js",
                "~/assets/vendor/wow/wow.min.js",
                "~/assets/vendor/pjax/jquery.pjax.js",
                "~/assets/vendor/footable/footable.all.min.js",
                "~/assets/custom/js/custom.js"));
            #endregion
        }
    }
}

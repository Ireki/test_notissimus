using Android.App;
using Android.OS;
using Android.Widget;

namespace test_notissimus {
    [Activity(Label = "ContentActivity")]
    public class ContentActivity : Activity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_content);

            TextView textOffer = FindViewById<TextView>(Resource.Id.json_text_offer);
            if (this.Intent.Extras.ContainsKey("result")) {
                var resultData = this.Intent.Extras.Get("result");
                textOffer.Text = resultData.ToString();

            }
        }
    }
}
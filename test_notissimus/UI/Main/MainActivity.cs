using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using AndroidX.Lifecycle;
using AndroidX.RecyclerView.Widget;
using test_notissimus.UI.Main;

namespace test_notissimus
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        private MainActivityViewModel ViewModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            RecyclerView mRecyclerView = FindViewById<RecyclerView>(Resource.Id.offer_list);
            RecyclerView.LayoutManager mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);
            ViewModel = new ViewModelProvider(this).Get(Java.Lang.Class.FromType(typeof(MainActivityViewModel))) as MainActivityViewModel;

            ViewModel.Offers.CollectionChanged += (sender, e) => {
                OfferListAdapter mAdapter = new OfferListAdapter(ViewModel.Offers);
                mAdapter.ItemClick += OnItemClick;
                mRecyclerView.SetAdapter(mAdapter);
            };


        }




        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults){
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void OnItemClick(object sender, int position) {

            var intent = new Intent(this, typeof(ContentActivity));
            intent.PutExtra("result", ViewModel.SerializeOffer(position));
            StartActivity(intent);
        }
    }
}
using AndroidX.Lifecycle;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using test_notissimus.Data;
using test_notissimus.Network;


namespace test_notissimus.UI.Main {
    public class MainActivityViewModel : ViewModel {

        public ObservableCollection<Offer> Offers;

        public MainActivityViewModel() {
            LoadOfferAsync();
        }



        public string SerializeOffer(int position) {
            return JsonConvert.SerializeObject(Offers[position], Formatting.Indented);
        }


        async void LoadOfferAsync() {
            Offers = new ObservableCollection<Offer>();

            var offers = await Service.GetOffers();
            foreach (var offer in offers) {
                Offers.Add(offer);
            }

        }


    }
}
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using test_notissimus.Data;

namespace test_notissimus {
    class OfferListAdapter : RecyclerView.Adapter {

        public ObservableCollection<Offer> Offers;
        public event EventHandler<int> ItemClick;

        public OfferListAdapter(ObservableCollection<Offer> offers) {
            this.Offers = offers;
        }

        public override RecyclerView.ViewHolder
            OnCreateViewHolder(ViewGroup parent, int viewType) {
            View itemView = LayoutInflater.From(parent.Context).
            Inflate(Resource.Layout.list_item_offer, parent, false);
            OfferViewHolder vh = new OfferViewHolder(itemView, OnClick);
            return vh;
        }

        public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position) {
            OfferViewHolder vh = holder as OfferViewHolder;
            vh.IdOfferText.Text = Offers[position].Id;
        }

        public override int ItemCount {
            get { return Offers.Count; }
        }

        void OnClick(int position) {
            if (ItemClick != null)
                ItemClick(this, position);
        }

    }

    class OfferViewHolder : RecyclerView.ViewHolder {
        public TextView IdOfferText { get; private set; }

        public OfferViewHolder(View itemView, Action<int> listener) : base(itemView) {
            IdOfferText = itemView.FindViewById<TextView>(Resource.Id.id_offer);
            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
}
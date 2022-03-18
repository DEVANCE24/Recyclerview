using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace recyclerview
{

    class Country : RecyclerView.Adapter

    {
        private List<string> _employeeName;
        public event EventHandler<int> ItemClick;




        public Country(List<string> employeeName)
        {
            _employeeName = employeeName;
        }

        public override int ItemCount => _employeeName.Count;


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {

            EmlpoyeeViewHolder emlpoyeeViewHolder = holder as EmlpoyeeViewHolder;
            emlpoyeeViewHolder.Binddata(_employeeName[position]);

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Country_list, parent, false);

            return new EmlpoyeeViewHolder(view, OnClick);

        }

        public void OnClick(int position)
        {
            if (ItemClick != null)
            {
                ItemClick?.Invoke(this, position);
            }

            ItemClick?.Invoke(this, position);
        }


        class EmlpoyeeViewHolder : RecyclerView.ViewHolder
        {
            public TextView _employeeNameText;


            public EmlpoyeeViewHolder(View itemView, Action<int> listner) : base(itemView)
            {
                _employeeNameText = itemView.FindViewById<TextView>(Resource.Id._employeeText);
                _employeeNameText.Click += (sender, e) => listner(base.LayoutPosition);
            }
            internal void Binddata(string employeeName)
            {
                _employeeNameText.Text = employeeName;
            }


        }
    }


}

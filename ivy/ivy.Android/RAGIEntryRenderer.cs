using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using RAGI;
using ivy.Droid;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(RAGIEntry), typeof(RAGIEntryRenderer))]

namespace ivy.Droid
{
    public class RAGIEntryRenderer: EntryRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.White);
                Control.SetTextColor(global::Android.Graphics.Color.Black);
            }
        }

    }
}
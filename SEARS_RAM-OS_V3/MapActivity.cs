using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace SEARS_RAM_OS_V3
{
    [Activity(Label = "MapActivity")]
    public class MapActivity : Activity, IOnMapReadyCallback
    {
        GoogleMap googleMap;
        public void OnMapReady(GoogleMap googleMap)
        {
            this.googleMap = googleMap;
            var builder = CameraPosition.InvokeBuilder();
            builder.Target(new LatLng(21.159527552219018, -101.69470674603781));
            builder.Zoom(16);
            var cameraPosition = builder.Build();
            var cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
            this.googleMap.AnimateCamera(cameraUpdate);
            MarkerOptions markerOpt1 = new MarkerOptions();
            markerOpt1.SetPosition(new LatLng(21.159527552219018, -101.69470674603781));
            markerOpt1.SetTitle("SEARS Plaza Mayor");
            googleMap.AddMarker(markerOpt1);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_mapa);


            var mapview = FindViewById<MapView>(Resource.Id.map);
            mapview.OnCreate(savedInstanceState);
            mapview.GetMapAsync(this);
            MapsInitializer.Initialize(this);


            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                Window window = Window;
                window.AddFlags(WindowManagerFlags.LayoutNoLimits);
                window.AddFlags(WindowManagerFlags.TranslucentNavigation);
            }

            var btnMenu = FindViewById<ImageButton>(Resource.Id.btnmenumapa);

            btnMenu.Click += delegate
            {
                var MenuIntent = new Intent(this, typeof(ActivityMenu));
                StartActivity(MenuIntent);
            };

        }



    }
}
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace SEARS_RAM_OS_V3
{
    [Activity(Label = "ActivityMenu")]
    public class ActivityMenu : Activity
    {
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_menu);
          
            // Create your application here
            #region Type Faces Roboto
            var typefaceThin = Typeface.CreateFromAsset(this.Assets, "fonts/robotothin.ttf");
            var typefaceLightItalic = Typeface.CreateFromAsset(this.Assets, "fonts/robotolightitalic.ttf");
            var typefaceLight = Typeface.CreateFromAsset(this.Assets, "fonts/robotolight.ttf");
            var typefaceRegular = Typeface.CreateFromAsset(this.Assets, "fonts/robotoregular.ttf");
            var typefacemedium = Typeface.CreateFromAsset(this.Assets, "fonts/robotomedium.ttf");
            #endregion

            var txtTitleMenu = FindViewById<TextView>(Resource.Id.txtTitleMenu);
            txtTitleMenu.SetTypeface(typefacemedium, TypefaceStyle.Normal);
            var btnInicioMenu = FindViewById<Button>(Resource.Id.btniniciomenu);
            btnInicioMenu.SetTypeface(typefaceRegular, TypefaceStyle.Normal);
            var btnDepartamentos = FindViewById<Button>(Resource.Id.btndepartamentosmenu);
            btnDepartamentos.SetTypeface(typefaceRegular, TypefaceStyle.Normal);
            var btnCreditos = FindViewById<Button>(Resource.Id.btncreditosmenu);
            btnCreditos.SetTypeface(typefaceRegular, TypefaceStyle.Normal);
            var btnNosotros = FindViewById<Button>(Resource.Id.btnnosotros);
            btnNosotros.SetTypeface(typefaceRegular, TypefaceStyle.Normal);
            var btnMapa = FindViewById<Button>(Resource.Id.btnubicador);
            btnMapa.SetTypeface(typefaceRegular, TypefaceStyle.Normal);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                Window window = Window;
                window.AddFlags(WindowManagerFlags.LayoutNoLimits);
                window.AddFlags(WindowManagerFlags.TranslucentNavigation);
            }

            btnInicioMenu.Click += delegate
            {
                var InicioIntent = new Intent(this, typeof(MainActivity));
                StartActivity(InicioIntent);
            };
            btnDepartamentos.Click += delegate
            {
                /*var DepartamentosIntent = new Intent(this, typeof(ActivityDepartamentos));
                StartActivity(DepartamentosIntent);*/
                var ProductoIntent = new Intent(this, typeof(ActivityProductos));
                StartActivity(ProductoIntent);
            };
            btnCreditos.Click += delegate
            {
                var CreditosIntent = new Intent(this, typeof(ActivityCreditos));
                StartActivity(CreditosIntent);
            };
            btnNosotros.Click += delegate
            {
                var NosotrosIntent = new Intent(this, typeof(ActivityNosotros));
                StartActivity(NosotrosIntent);
            };
            btnMapa.Click += delegate
            {
                var MapaIntent = new Intent(this, typeof(MapActivity));
                StartActivity(MapaIntent);
            };
        }
    }
}
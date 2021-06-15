using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using AndroidX.Core.Graphics.Drawable;
using System;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Views;

namespace SEARS_RAM_OS_V3
{
    [Activity(Label = "ProductDetailActivity")]
    public class ProductDetailActivity : Activity
    {
        TextView txtNombre, txtPrecio, txtDescripcion, txtMarca, txtSku;
        ImageView Imagen;
        string nombre, departamento, descripcion, imagen, marca, sku;
        double precio;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.product_detail);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                Window window = Window;
                window.AddFlags(WindowManagerFlags.LayoutNoLimits);
                window.AddFlags(WindowManagerFlags.TranslucentNavigation);
            }

            var btnMenuDetail = FindViewById<ImageButton>(Resource.Id.btnmenuprdetail);
            btnMenuDetail.Click += delegate
            {
               
                var MenuIntent = new Intent(this, typeof(ActivityMenu));
                StartActivity(MenuIntent);
            };

            try
            {
                departamento = Intent.GetStringExtra("departamento");
                imagen = Intent.GetStringExtra("imagen");
                nombre = Intent.GetStringExtra("nombre");
                marca = Intent.GetStringExtra("marca");
                sku = Intent.GetStringExtra("sku");
                descripcion = Intent.GetStringExtra("descripcion");
                precio = double.Parse(Intent.GetStringExtra("precio"));


                Imagen = FindViewById<ImageView>(Resource.Id.imagenproducto_dsp);
                txtNombre = FindViewById<TextView>(Resource.Id.txtproducto_dsp);
                txtPrecio = FindViewById<TextView>(Resource.Id.txtprecio_dsp);
                txtDescripcion = FindViewById<TextView>(Resource.Id.txtdescripcion_dsp);
                txtMarca = FindViewById<TextView>(Resource.Id.txtmarca_dsp);
                txtSku = FindViewById<TextView>(Resource.Id.txtsku_dsp);
                txtNombre.Text = nombre;
                txtDescripcion.Text = descripcion;
                txtMarca.Text = "Marca: " + marca;
                txtSku.Text = "SKU# " + sku;
                txtPrecio.Text = "$" + String.Format("{0:n}", precio);
                
                
                var RutaImagen = System.IO.Path.Combine(System.Environment.
                    GetFolderPath(System.Environment.SpecialFolder.Personal),
                    imagen);
   
                var rutauriimagen = Android.Net.Uri.Parse(RutaImagen);
                
                Imagen.SetImageURI(rutauriimagen);
                

                var opciones = new BitmapFactory.Options();
                opciones.InPreferredConfig = Bitmap.Config.Argb8888;
                var bitmap = BitmapFactory.DecodeFile(RutaImagen, opciones);
                Imagen.SetImageDrawable(getRoundedCornerImage(bitmap, 20));

            }
            catch (System.Exception ex)
            {
                throw;
            }

        }

        public static RoundedBitmapDrawable

          getRoundedCornerImage
          (Bitmap image, int cornerRadius)
        {
            var corner =
                RoundedBitmapDrawableFactory.Create(null, image);
            corner.CornerRadius = cornerRadius;
            return corner;
        }

    }

}

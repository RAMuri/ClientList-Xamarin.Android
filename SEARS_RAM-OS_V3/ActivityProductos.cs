using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SEARS_RAM_OS_V3
{
    [Activity(Label = "ActivityProductos")]
    public class ActivityProductos : Activity
    {
        //AppCompat
        Android.App.ProgressDialog progress;
        string elementoimagen;
        ListView listado;
        List<Producto> ListadeClientes = new List<Producto>();
        List<ElementosdelaTabla> ElementosTabla = new List<ElementosdelaTabla>();
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_productos);
            //SupportActionBar.Hide();
            listado = FindViewById<ListView>(Resource.Id.Lista);
            progress = new Android.App.ProgressDialog(this);
            progress.Indeterminate = true;
            progress.SetProgressStyle(Android.App.ProgressDialogStyle.Spinner);
            progress.SetMessage("Cargando...");
            progress.SetCancelable(false);
            progress.Show();
            await CargarDatosAzure();
            progress.Hide();

            var menuBtnPr = FindViewById<ImageButton>(Resource.Id.btnmenupr);

            menuBtnPr.Click += delegate
            {
                var MenuIntent = new Intent(this, typeof(ActivityMenu));
                StartActivity(MenuIntent);
            };

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                Window window = Window;
                window.AddFlags(WindowManagerFlags.LayoutNoLimits);
                window.AddFlags(WindowManagerFlags.TranslucentNavigation);
            }
        }

        public async Task CargarDatosAzure()
        {
            try
            {

                var Titulo = FindViewById<TextView>(Resource.Id.txttitleproductos);

                var CuentadeAlmacenamiento = CloudStorageAccount.Parse
                    ("DefaultEndpointsProtocol=https;AccountName=programacionmoviles;AccountKey=K4HLGMkMGB87LlncsykIQe5QO85Ges6DDZ1wjK8M7EFpZeR+k+7fKLm3uy3th+R6mvmYeDa6pf2sn62Q3dZkWg==;EndpointSuffix=core.windows.net");
                var ClienteBlob = CuentadeAlmacenamiento.CreateCloudBlobClient();
                var Contenedor = ClienteBlob.GetContainerReference("sears");
                var TablaNoSQL = CuentadeAlmacenamiento.CreateCloudTableClient();
                var Tabla = TablaNoSQL.GetTableReference("sears");
                var Consulta = new TableQuery<Producto>();
                TableContinuationToken token = null;
                
                
                    var Datos = await Tabla.ExecuteQuerySegmentedAsync<Producto>
                    (Consulta, token, null, null);
                    ListadeClientes.AddRange(Datos.Results);
     
                int iNombre = 0;
                int iImagen = 0;
                int iDepartamento = 0;
                int iDescripcion = 0;
                int iMarca = 0;
                int iSku = 0;
                int iPrecio = 0;

                ElementosTabla = ListadeClientes.Select(r => new ElementosdelaTabla()
                {
                    
                    Nombre = ListadeClientes.ElementAt(iNombre++).RowKey,
                    Imagen = ListadeClientes.ElementAt(iImagen++).Imagen,
                    Departamento = ListadeClientes.ElementAt(iDepartamento++).Departamento,
                    Descripcion = ListadeClientes.ElementAt(iDescripcion++).Descripcion,
                    Marca = ListadeClientes.ElementAt(iMarca++).Marca,
                    Sku = ListadeClientes.ElementAt(iSku++).SKU,
        
                    Precio = ListadeClientes.ElementAt(iPrecio++).Precio
                }).ToList();
                int contadorimagen = 0;
                while (contadorimagen < ListadeClientes.Count)
                {
                    elementoimagen = ListadeClientes.ElementAt(contadorimagen).Imagen;
                    
                    var ImagenBlob = Contenedor.GetBlockBlobReference(elementoimagen);
                    var rutaimagen = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                   
                    var ArchivoImagen = System.IO.Path.Combine(rutaimagen, elementoimagen);
                   
                    var StreamImagen = File.OpenWrite(ArchivoImagen);
                   
                    await ImagenBlob.DownloadToStreamAsync(StreamImagen);
 
                    contadorimagen++;

                }
                listado.Adapter = new DataAdapter(this, ElementosTabla);
                listado.ItemClick += OnListItemClick;

            }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }

        }
        public void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var Datasend = ElementosTabla[e.Position];
            var DataIntent = new Intent(this, typeof(ProductDetailActivity));
            DataIntent.PutExtra("departamento", Datasend.Departamento);
            DataIntent.PutExtra("imagen", Datasend.Imagen);
            DataIntent.PutExtra("descripcion", Datasend.Descripcion);
            DataIntent.PutExtra("nombre", Datasend.Nombre);
            DataIntent.PutExtra("marca", Datasend.Marca);
            DataIntent.PutExtra("sku", Datasend.Sku);
            DataIntent.PutExtra("precio", Datasend.Precio.ToString());
            
            StartActivity(DataIntent);
        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
    public class ElementosdelaTabla
    {

        public string Nombre { get; set; }
        public string Departamento { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public string Marca{ get; set; }
        public string Sku { get; set; }
        public double Precio { get; set; }
    }

    public class Producto : TableEntity
    {
        public Producto(string Categoria, string Nombre)
        {
            PartitionKey = Categoria;
            RowKey = Nombre;

        }

        public Producto() { }

        public string Nombre { get; set; }
        public string Departamento { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string SKU { get; set; }
        public double Precio { get; set; }
    }
}
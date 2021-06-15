using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace SEARS_RAM_OS_V3
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
       
        

        protected override void OnCreate(Bundle savedInstanceState)
        {   
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            #region variables
            var menuBtnInicio = FindViewById<ImageButton>(Resource.Id.btnmenuInicio);
            
            var btnAsus = FindViewById<ImageButton>(Resource.Id.imagebuttonItem1);
            var btnPantalla = FindViewById<ImageButton>(Resource.Id.imagebuttonItem2);
            var btnPlay5 = FindViewById<ImageButton>(Resource.Id.imagebuttonItem3);
            var btnS21 = FindViewById<ImageButton>(Resource.Id.imagebuttonItem4);
            var btnVestido = FindViewById<ImageButton>(Resource.Id.imagebuttonItem5);
            var btnCasio = FindViewById<ImageButton>(Resource.Id.imagebuttonItem6);
            var btnBolsa = FindViewById<ImageButton>(Resource.Id.imagebuttonItem7);
            var btnPolo = FindViewById<ImageButton>(Resource.Id.imagebuttonItem8);
            var txtAsus = FindViewById<TextView>(Resource.Id.txtitem1);
            var txtPantalla = FindViewById<TextView>(Resource.Id.txtitem2);
            var txtPlay5 = FindViewById<TextView>(Resource.Id.txtitem3);
            var txtS21 = FindViewById<TextView>(Resource.Id.txtitem4);
            var txtVestido = FindViewById<TextView>(Resource.Id.txtitemdama1);
            var txtCasio = FindViewById<TextView>(Resource.Id.txtitemdama2);
            var txtBolsa = FindViewById<TextView>(Resource.Id.txtitemdama3);
            var txtPolo = FindViewById<TextView>(Resource.Id.txtitemdama4);
            
            #endregion


            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                Window window = Window;
                window.AddFlags(WindowManagerFlags.LayoutNoLimits);
                window.AddFlags(WindowManagerFlags.TranslucentNavigation);             
            }

            #region Botones Productos Inicio
            
            menuBtnInicio.Click += delegate
            {
                var MenuIntent = new Intent(this, typeof(ActivityMenu));
                StartActivity(MenuIntent);
            };
            
            btnAsus.Click += delegate
            {
                var MenuIntent = new Intent(this, typeof(ProductDetailActivity));     
                MenuIntent.PutExtra("departamento", "Computación");
                MenuIntent.PutExtra("imagen", "quince.jpg");
                MenuIntent.PutExtra("descripcion", "Extiende tu personalidad con la nueva Laptop ASUS VivoBook D533. Equipada con la última tecnología del Procesador AMD Ryzen™ 5 de 6 núcleos y en color verde Gaia Green, esta potente laptop se convertirá en una extensión de tu personalidad. Rompe lo tradicional y sorprende al mundo desde casa con esta laptop diseñada para realizar múltiples tareas, dando el máximo en todo momento. Ya sea para trabajar, estudiar o entretenerte con tus películas y series favoritas, esta laptop cuenta con una pantalla de 15 pulgadas FHD NanoEdge de cuatro lados sin marco para una experiencia visual más amplia. Además, disfruta de 512GB de almacenamiento de estado sólido que te dará mayor rapidez en la apertura de programas y en tus tareas y una memora RAM de 16B. La Laptop ASUS VivoBook D533 también protege tu información gracias a su desbloqueo con huella digital, y te da máxima comodidad gracias a su Bisagra ErgoLift que eleva el teclado. Tu nueva laptop ASUS VivoBook D533 sorprende al mundo. Medida: 35.98 x 23.38 x 1.61cm Peso: 1.80Kg");
                MenuIntent.PutExtra("nombre", txtAsus.Text);
                MenuIntent.PutExtra("marca", "Asus");
                MenuIntent.PutExtra("sku", "25068320");
                MenuIntent.PutExtra("precio", "20249");
                StartActivity(MenuIntent);
            };
            btnPantalla.Click += delegate
            {
                var MenuIntent = new Intent(this, typeof(ProductDetailActivity));
                MenuIntent.PutExtra("departamento", "Electronica y Tecnología");
                MenuIntent.PutExtra("imagen", "cuatro.png");
                MenuIntent.PutExtra("descripcion", "Siéntete parte de las películas o series que ves en casa con la impecable calidad que te ofrece la pantalla Samsung Led curva de 55 pulgadas, una pantalla de primer nivel y sumamente elegante que se adapta naturalmente a tu espacio.  Observa cómo sus colores nítidos y vibrantes hacen que las imágenes cobren vida. Una vez que experimentes su amplia gama de colores nada será igual. Disfruta imágenes más nítidas con UHD 4K TV, que tiene 4 veces más pixeles que una FHD TV. Ahora podrás ver incluso los detalles más pequeños.  También te ofrece el controla fácil de tu contenido y dispositivos vinculados, con One Remote Control; esta pantalla Samsung curva es una de las mejores y más competentes del mercado.  Gracias a que cuenta con una función de detección automática que conecta y reconoce tus dispositivos instantáneamente, ahora todo es más fácil de encontrar y usar. No lo pienses más, si buscas una nueva pantalla, este modelo de Samsung es para ti.");
                MenuIntent.PutExtra("nombre", txtPantalla.Text);
                MenuIntent.PutExtra("marca", "SAMSUNG");
                MenuIntent.PutExtra("sku", "98665600");
                MenuIntent.PutExtra("precio", "32599");
                StartActivity(MenuIntent);
            };
            btnPlay5.Click += delegate
            {
                var MenuIntent = new Intent(this, typeof(ProductDetailActivity));
                MenuIntent.PutExtra("departamento", "Videojuegos");
                MenuIntent.PutExtra("imagen", "siete.png");
                MenuIntent.PutExtra("descripcion", "La consola PS5 revela nuevas posibilidades de juegos que nunca imaginaste. Experimenta una velocidad sorprendente de carga con una inmersión más intensa gracias a la SSD de ultraalta velocidad, compatible con respuesta háptica, gatillos adaptativos y audio 3D, y la generación totalmente nueva de increíbles juegos de PlayStation. Disfruta de la potencia de una CPU, una GPU y una SSD personalizadas con E/S integradas que redefinirán lo que una consola PlayStation puede hacer. Maravíllate con asombrosos gráficos y descubre las nuevas funciones de PS5. Descubre una experiencia de juego más inmersiva con soporte para respuesta háptica, gatillos adaptativos y tecnología de audio 3D.");
                MenuIntent.PutExtra("nombre", txtPlay5.Text);
                MenuIntent.PutExtra("marca", "SONY");
                MenuIntent.PutExtra("sku", "884095198954");
                MenuIntent.PutExtra("precio", "21999");
                StartActivity(MenuIntent);
            };
            btnS21.Click += delegate
            {
                var MenuIntent = new Intent(this, typeof(ProductDetailActivity));
                MenuIntent.PutExtra("departamento", "Telefonía");
                MenuIntent.PutExtra("imagen", "doce.jpg");
                MenuIntent.PutExtra("descripcion", "Hecho para lo épico de todos los días, así es el nuevo Samsung S21+ G996. De entrada podrás disfrutar de una pantalla de 6.7 pulgadas con resolución de 1080 x 2400 pixeles, 20:9 ratio (~394 ppi density) para que no te pierdas de ningún detalle. Este gran Smartphone de Samsung está diseñado para resolver el video y la fotografía, con una resolución cinematográfica de 8K para que puedas tomar formas épicas mientras haces un video. Disfruta de una cámara trasera de 12 MP+ 64 MP+ 12 MP para que puedas capturar la toma perfecta. Y no solo eso, no tendrás de que preocuparte con su memoria interna de 128 GB y memoria RAM de 8GB, sistema operativo Android 11, One UI 3.1 y procesador Qualcomm SM8350 Snapdragon 888 (5 nm) - USA/China. Ambos modelos tienen todas las características que necesitas: 64 MP, el chip más rápido y una batería increíble que dura todo el día. Tu mundo será realmente épico con el Samsung S21+ G996. Protección Revolucionaria: Creado para esos momentos &quot;¡oh no!&quot;, Corning® Gorilla® Glass Victus™ ofrece resistencia a los rayones y los daños, lo que lo hace el más duro en teléfonos inteligentes. No lo dudes más y adquiere este Samsung S21+ G996 en Sears.com.mx Dimensiones: alto 16.15 cm, frente 7.56 cm, fondo 0.78 cm y peso 200 gramos.");
                MenuIntent.PutExtra("nombre", txtS21.Text);
                MenuIntent.PutExtra("marca", "SAMSUNG");
                MenuIntent.PutExtra("sku", "24421949");
                MenuIntent.PutExtra("precio", "24999");
                StartActivity(MenuIntent);
            };
            btnVestido.Click += delegate
            {
                var MenuIntent = new Intent(this, typeof(ProductDetailActivity));
                MenuIntent.PutExtra("departamento", "Ella");
                MenuIntent.PutExtra("imagen", "once.jpg");
                MenuIntent.PutExtra("descripcion", "Vestido estampado de flores con vivos manga corta, falda tableada.  Manga: Corta Cuello: Camisero Diseño: Flores Modelo: DET1049 Composición: 100%Poliester Instrucciones de cuidado: Lavar a mano con jabón neutro");
                MenuIntent.PutExtra("nombre", txtVestido.Text);
                MenuIntent.PutExtra("marca", "Marca C2C");
                MenuIntent.PutExtra("sku", "92093980");
                MenuIntent.PutExtra("precio", "1999");
                StartActivity(MenuIntent);
            };
            btnCasio.Click += delegate
            {
                var MenuIntent = new Intent(this, typeof(ProductDetailActivity));
                MenuIntent.PutExtra("departamento", "Ella");
                MenuIntent.PutExtra("imagen", "dieciseis.jpg");
                MenuIntent.PutExtra("descripcion", "Reloj Casio, Vintage, Unisex, Con Cronómetro, Calendario Autómatico, Alarma, Mov. Cuarzo y Color Oro Rosa. Mod. B640WC-5AVT.");
                MenuIntent.PutExtra("nombre", txtCasio.Text);
                MenuIntent.PutExtra("marca", "CASIO");
                MenuIntent.PutExtra("sku", "2049791");
                MenuIntent.PutExtra("precio", "1849");
                StartActivity(MenuIntent);
            };
            btnBolsa.Click += delegate
            {
                var MenuIntent = new Intent(this, typeof(ProductDetailActivity));
                MenuIntent.PutExtra("departamento", "Ella");
                MenuIntent.PutExtra("imagen", "diecisiete.jpg");
                MenuIntent.PutExtra("descripcion", "Enamórate y crea looks increíbles con nuestro modelo de bolso Westies LAPINA25 tipo tote. Su silueta clásica te permitirá llevar todo con comodidad sin perder el estilo. ¡No te quedes sin la tuya!");
                MenuIntent.PutExtra("nombre", txtBolsa.Text);
                MenuIntent.PutExtra("marca", "WESTIES");
                MenuIntent.PutExtra("sku", "8366511");
                MenuIntent.PutExtra("precio", "1499");
                StartActivity(MenuIntent);
            };
            btnPolo.Click += delegate
            {
                var MenuIntent = new Intent(this, typeof(ProductDetailActivity));
                MenuIntent.PutExtra("departamento", "Ella");
                MenuIntent.PutExtra("imagen", "trece.jpg");
                MenuIntent.PutExtra("descripcion", "Playera tipo polo de manga corta con bordado enfrente, Ideal para lucir un Outfit Casual.");
                MenuIntent.PutExtra("nombre", txtPolo.Text);
                MenuIntent.PutExtra("marca", "POLO CLUB");
                MenuIntent.PutExtra("sku", "57875175");
                MenuIntent.PutExtra("precio", "319");
                StartActivity(MenuIntent);
            };
            
            #endregion

        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

}
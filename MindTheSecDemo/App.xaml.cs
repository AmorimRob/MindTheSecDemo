using Flurl.Http;
using Flurl.Http.Configuration;
using MindTheSecDemo.Security;
using MindTheSecDemo.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MindTheSecDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            FlurlHttp.Configure(c =>
            {
                c.HttpClientFactory = new SecureHttpClientFactory(new SecureHttpClient.SecureHttpClientHandler());
                var jsonSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                };
                c.JsonSerializer = new NewtonsoftJsonSerializer(jsonSettings);
            });

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
           
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

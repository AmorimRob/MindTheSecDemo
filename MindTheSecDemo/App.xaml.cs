using Flurl.Http;
using Flurl.Http.Configuration;
using MindTheSecDemo.Segurança;
using MindTheSecDemo.ViewModels;
using MindTheSecDemo.Views;
using Newtonsoft.Json;
using Prism;
using Prism.Ioc;
using SecureHttpClient;
using Xamarin.Forms;

namespace MindTheSecDemo
{
    public partial class App 
    {
        public App() : this(null)
        {
        }

        public App(IPlatformInitializer initializer) : base(initializer)
        {
        }


        protected override async void OnInitialized()
        {
            InitializeComponent();

            FlurlHttp.Configure(c =>
            {
                c.HttpClientFactory = Container.Resolve<SecureHttpClientFactory>();
                var jsonSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                };
                c.JsonSerializer = new NewtonsoftJsonSerializer(jsonSettings);
            });

            await NavigationService.NavigateAsync($"{nameof(SecureStoragePage)}");
        }


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(new SecureHttpClientHandler());

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<OfuscacaoPage, OfuscacaoPageViewModel>();
            containerRegistry.RegisterForNavigation<SecureStoragePage, SecureStoragePageViewModel>();
            containerRegistry.RegisterForNavigation<PokemonsPage, PokemonsPageViewModel>();
        }
    }
}

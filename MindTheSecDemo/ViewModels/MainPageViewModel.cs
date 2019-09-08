using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MindTheSecDemo.Segurança;
using MindTheSecDemo.Views;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MindTheSecDemo.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigatedAware
    {
        public readonly INavigationService _navigationService;

        public string Texto { get; set; }

        private string _textoOfuscado;
        public string TextoOfuscado
        {
            set 
            { 
                _textoOfuscado = value; 
                RaisePropertyChanged(nameof(TextoOfuscado)); 
            }

            get { return _textoOfuscado; }
        }

        private string _textoTransformado;
        public string TextoTransformado
        {
            set
            {
                _textoTransformado = value;
                RaisePropertyChanged(nameof(TextoTransformado));
            }

            get { return _textoTransformado; }
        }

        private string _textoParaSalvarNoSecureStorage;
        public string TextoParaSalvarNoSecureStorage
        {
            set
            {
                _textoParaSalvarNoSecureStorage = value;
                RaisePropertyChanged(nameof(TextoParaSalvarNoSecureStorage));
            }

            get { return _textoParaSalvarNoSecureStorage; }
        }

        private string _textoRecuperadoDoSecureStorage;
        public string TextoRecuperadoDoSecureStorage
        {
            set
            {
                _textoRecuperadoDoSecureStorage = value;
                RaisePropertyChanged(nameof(TextoRecuperadoDoSecureStorage));
            }

            get { return _textoRecuperadoDoSecureStorage; }
        }

        public ICommand OfuscarTextoCommand { get; set; }
        public ICommand ObterTextoCommand { get; set; }
        public ICommand NavegarPokemonsPageCommand { get; set; }
        public ICommand SalvarSecureStorageCommand { get; set; }
        public ICommand ObterSecureStorageCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            //OFUSCAÇÃO DE STRING
            OfuscarTextoCommand = new Command(() => TextoOfuscado = TransformStrings.Transform(Texto));

            ObterTextoCommand = new Command(() => TextoTransformado = TransformStrings.Decode(TextoOfuscado));

            //SECURE STORAGE
            SalvarSecureStorageCommand = new Command(async () => await SalvarInformacoesSeguras());

            ObterSecureStorageCommand = new Command(async () => await ObterInformacoesSeguras());

            //NAVEGAR
            NavegarPokemonsPageCommand = new Command(() => _navigationService.NavigateAsync($"{nameof(PokemonsPage)}"));
        }

        public async Task SalvarInformacoesSeguras()
        {
            try
            {
                await SecureStorage.SetAsync("token", TextoParaSalvarNoSecureStorage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task ObterInformacoesSeguras()
        {
            try
            {
                TextoRecuperadoDoSecureStorage = await SecureStorage.GetAsync("token");
            }
            catch (Exception)
            { }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
        }
    }
}

using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MindTheSecDemo.Views;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MindTheSecDemo.ViewModels
{
    public class SecureStoragePageViewModel :  BindableBase, INavigatingAware
    {
        private readonly INavigationService _navigationService;

        public ICommand NavegarParaOfuscacaoDeTextoCommand { get; }
        public ICommand SalvarSecureStorageCommand { get; set; }
        public ICommand ObterSecureStorageCommand { get; set; }

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

        public SecureStoragePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavegarParaOfuscacaoDeTextoCommand = new Command(async () 
                => await _navigationService.NavigateAsync(nameof(OfuscacaoPage)));

            //SECURE STORAGE
            SalvarSecureStorageCommand = new Command(async () => await SalvarInformacoesSeguras());

            ObterSecureStorageCommand = new Command(async () => await ObterInformacoesSeguras());

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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }
    }
}

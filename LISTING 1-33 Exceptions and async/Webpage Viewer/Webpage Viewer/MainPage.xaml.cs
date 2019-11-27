using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Net.Http;
using Windows.System.Threading;
using Windows.System;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Webpage_Viewer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        static async Task<string> FetchWebPage(string url)
        {
            HttpClient _httpClient = new HttpClient();
            return await _httpClient.GetStringAsync(url);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //CTO: O catch so ira executar porque o FetchWebPage esta retornando um valor, se ele nao retornasse o catch nao funcionaria
            try
            {
                ResultTextBlock.Text = await FetchWebPage(URLTextBox.Text);
                StatusTextBlock.Text = "Page Loaded";
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = ex.Message;
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
        }
    }
}

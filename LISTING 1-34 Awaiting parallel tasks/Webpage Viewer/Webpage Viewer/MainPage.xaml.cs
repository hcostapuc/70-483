using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;


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

        static async Task<IEnumerable<string>> FetchWebPages(string[] urls)
        {
            var tasks = new List<Task<String>>();

            foreach (string url in urls)
            {
                tasks.Add(FetchWebPage(url));
            }
            //CTO: o metodo WhenAll cria uma task que termina quando as tasks passadas no parametro terminar, esse cenário é bom
            //quando você precisaria inserir varios awaits em tasks internas do metodo async.
            //Esse caso nao é uma boa pratica pois nao teremos um retorno ordenado dos nomes dos sites, nao possue exeptions throws
            return await Task.WhenAll(tasks);

            //CTO: O waitany diferente do whenAll termina a task criada quando qualquer uma das task completar.
            return await Task.WaitAny(tasks);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] names = URLTextBox.Text.Split(new char[] { ',' });

                var pages = await FetchWebPages(names);

                string fullText = "";

                foreach (string page in pages)
                {
                    fullText += page;
                }
                ResultTextBlock.Text = fullText;

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

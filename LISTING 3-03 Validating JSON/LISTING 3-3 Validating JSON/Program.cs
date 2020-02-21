using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LISTING_3_3_Validating_JSON
{
    class MusicTrack
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }

        // ToString that overrides the behavior in the base class
        public override string ToString()
        {
            return Artist + " " + Title + " " + Length.ToString() + " seconds long";
        }

        public MusicTrack(string artist, string title, int length)
        {
            Artist = artist;
            Title = title;
            Length = length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string invalidJson = "{\"Artist\":\"Rob Miles\",\"Title\":\"My Way\",\"Length\":150\"}";

            try
            {
                //CTO: se sua aplicação faz muita inserção e deleção de data e precisa de uma lista grande
                //podemos usar o LinkedList<t> ele da maior mobilidade do que o List para manipular a lista

                //CTO: Dica: usar link para qualquer busca ou ordenação de uma lista de objetos

                //CTO: Dica: quando for criar o CRUD, bas usar o metodo scafollding, que basicamente cria o crud
                //automaticamente usando a controller e a model (primeiro cria a model depois a controller e logo aparecera a opção de criação via scafollding)
                MusicTrack trackRead = JsonConvert.DeserializeObject<MusicTrack>(invalidJson);
                Console.Write("Read back: ");
                Console.WriteLine(trackRead);
            }
            catch (JsonReaderException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}

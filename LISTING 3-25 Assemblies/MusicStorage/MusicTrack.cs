namespace MusicStorage
{
    public class MusicTrack
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        //CTO: essa DLL esta com strong name assembly isso diz que a mesma possui um nome criptografado
        //isso nos da o beneficio de somente as dlls ou exes que a utilizam serão as únicas, ou seja,
        //dll fora do projeto não consegue acesso a essa dll, outra coisa são programas externos que utilizam
        //dll com o nome parecido e de versão diferente, poderia dar conflito. no exercicio 3-26 mostra melhor o exemplo

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
}

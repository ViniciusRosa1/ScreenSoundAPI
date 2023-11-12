using ScreenSoundAPI.Modelos;
using System.Text.Json;
using ScreenSoundAPI.Filtros;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

        LinqFilter.FiltrarMusicasEmCSharp(musicas);

        //musicas[1].ExibirDetalhesDaMusica();
        //LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
        //LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
        //LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "rock");
        //LinqFilter.FiltrarMusicasDeUmArtista(musicas, "U2");


        var musicasPreferidasDoVinicius = new MusicasPreferidas("Daniel");
        musicasPreferidasDoVinicius.AdicionarMusicasFavoritas(musicas[1]);
        musicasPreferidasDoVinicius.AdicionarMusicasFavoritas(musicas[377]);
        musicasPreferidasDoVinicius.AdicionarMusicasFavoritas(musicas[4]);
        musicasPreferidasDoVinicius.AdicionarMusicasFavoritas(musicas[6]);
        musicasPreferidasDoVinicius.AdicionarMusicasFavoritas(musicas[1467]);


        musicasPreferidasDoVinicius.GerarArquivoJson();


    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}
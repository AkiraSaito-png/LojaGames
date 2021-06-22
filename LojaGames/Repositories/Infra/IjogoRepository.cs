using LojaGames.DTOs.Request;
using LojaGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaGames.Repositories.Infra
{
    public interface IjogoRepository : IDisposable
    {
        Task<List<Jogo>> Obter(int page, int quantidade);
        Task<List<Jogo>> ObterPorProdutora(string nome, string produtora);
        Task<Jogo> ObterPorId(Guid id);
        Task Inserir(Jogo jogo);
        Task Atualizar(Jogo jogo);
        Task Remover(Guid id);
    }
}

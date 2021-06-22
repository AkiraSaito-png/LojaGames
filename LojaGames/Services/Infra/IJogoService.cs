using LojaGames.DTOs.Request;
using LojaGames.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaGames.Services.Infra
{
    public interface IJogoService : IDisposable
    {
        Task<List<GameResponseDTO>> Obter(int page, int quantidade);
        Task<GameResponseDTO> ObterPorId(Guid id);
        Task<GameResponseDTO> Inserir(GameRequestDTO jogo);
        Task Atualizar(Guid id, GameRequestDTO jogo);
        Task AtualizarPreco(Guid id, int preco);
        Task Remover(Guid id);
    }
}

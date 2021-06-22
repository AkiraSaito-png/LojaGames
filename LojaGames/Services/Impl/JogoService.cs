using LojaGames.DTOs.Request;
using LojaGames.DTOs.Response;
using LojaGames.Models;
using LojaGames.Repositories.Infra;
using LojaGames.Services.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaGames.Services.Impl
{
    public class JogoService : IJogoService
    {
        private readonly IjogoRepository _JogoRepository;

        public JogoService(IjogoRepository JogoRepository)
        {
            _JogoRepository = JogoRepository;
        }
        public async Task Atualizar(Guid id, GameRequestDTO jogo)
        {
            var entidadeJogo = await _JogoRepository.ObterPorId(id);

            if (entidadeJogo == null)
                throw new Exception();

            entidadeJogo.Nome = jogo.Nome;
            entidadeJogo.Produtora = jogo.Produtora;
            entidadeJogo.Preco = jogo.Preco;

            await _JogoRepository.Atualizar(entidadeJogo);
        }

        public async Task AtualizarPreco(Guid id, int Preco)
        {
            var entidadeJogo = await _JogoRepository.ObterPorId(id);

            if (entidadeJogo == null)
                throw new Exception();
            
            entidadeJogo.Preco = Preco;
            await _JogoRepository.Atualizar(entidadeJogo);
        }

        public void Dispose()
        {
            _JogoRepository?.Dispose();
        }

        public async Task<GameResponseDTO> Inserir(GameRequestDTO jogo)
        {
            var entidadeJogo = await _JogoRepository.ObterPorProdutora(jogo.Nome, jogo.Produtora);

            if (entidadeJogo.Count > 0)
                return null;

            var jogoInsert = new Jogo
            {
                Id = Guid.NewGuid(),
                Nome = jogo.Nome,
                Preco = jogo.Preco,
                Produtora = jogo.Produtora
            };

            await _JogoRepository.Inserir(jogoInsert);

            return new GameResponseDTO
            {
                Id = jogoInsert.Id,
                Nome = jogoInsert.Nome,
                Preco = jogoInsert.Preco,
                Produtora = jogoInsert.Produtora
            };
        }

        public async Task<List<GameResponseDTO>> Obter(int page, int quantidade)
        {
            var jogo = await _JogoRepository.Obter(page, quantidade);

            return jogo.Select(jogo => new GameResponseDTO
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Preco = jogo.Preco,
                Produtora = jogo.Produtora
            }).ToList();
        }

        public async Task<GameResponseDTO> ObterPorId(Guid id)
        {
            var jogo = await _JogoRepository.ObterPorId(id);

            if (jogo == null)
                return null;

            return new GameResponseDTO
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Preco = jogo.Preco,
                Produtora = jogo.Produtora
            };
        }

        public async Task Remover(Guid id)
        {
            var jogo = await _JogoRepository.ObterPorId(id);

            if (jogo == null)
                throw new Exception();

            await _JogoRepository.Remover(id);

        }
    }
}

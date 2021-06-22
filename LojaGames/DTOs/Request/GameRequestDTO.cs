using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LojaGames.DTOs.Request
{
    public class GameRequestDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "o nome do jogo deve ser de 3 a 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "o nome do jogo deve ser de 3 a 100 caracteres")]
        public string Produtora { get; set; }
        [Required]
        [Range(1,10000, ErrorMessage = "o nome do jogo deve ser de 3 a 100 caracteres")]
        public int Preco { get; set; }

    }
}

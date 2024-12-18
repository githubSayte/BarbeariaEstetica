﻿using System.ComponentModel.DataAnnotations;

namespace Barbearia_Estética.Models
{ 
    public class LoginViewModel
    {
    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "O formato do e-mail é inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória.")]
    public string Senha { get; set; }
    }
}

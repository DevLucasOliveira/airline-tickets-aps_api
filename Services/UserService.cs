﻿using AirlineTickets.Api.Commands;
using AirlineTickets.Api.Models;
using AirlineTickets.Api.Properties;
using AirlineTickets.Api.Repositories.Interfaces;
using AirlineTickets.Api.Services.Interfaces;
using AirlineTickets.Api.ValueObjects;
using Flunt.Notifications;
using JWT.Service;

namespace AirlineTickets.Api.Services
{
    public class UserService : Notifiable, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public GenericCommandResult Register(RegisterUserCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao cadastrar o usuário", command.Notifications);

            if (_userRepository.UserExists(command.Email))
                return new GenericCommandResult(false, "Usuário já cadastrado", command.Email);

            var password = new Password(command.Password);
            if (password.Invalid)
                return new GenericCommandResult(false, "Senha inválida", password.Notifications);

            password.CreatePasswordHash(command.Password);
            var user = new User(command.Email, command.Name, password);

            _userRepository.Register(user);

            return new GenericCommandResult(true, "Usuário cadastrado com sucesso", (DTOs.User)user);
        }

        public GenericCommandResult Authenticate(AuthenticateUserCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao autenticar o usuário", command.Notifications);

            var user = _userRepository.Authenticate(command.Email);

            if (user == null)
                return new GenericCommandResult(false, "Usuário inválido", command.Notifications);

            var password = Password.VerifyPasswordHash(command.Password, user.PasswordHash, user.PasswordSalt);
            if (!password)
                return new GenericCommandResult(false, "Senha incorreta", Notifications);

            var token = TokenService.GenerateToken(user.Id.ToString(), Settings.Secret, 6);
            user.Token = token;

            return new GenericCommandResult(true, "Usuário autenticado com sucesso", (DTOs.User)user);
        }



    }
}

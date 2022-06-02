using System.Security.Cryptography;
using FluentValidation;
using Questor.DAL.Models;
using Questor.Services.Interfaces;
using Questor.DAL.Interface.Repositories;
using Questor.Services.Validators;

namespace Questor.Services.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly UserValidator userValidator;

    public UserService(IUserRepository userRepository, UserValidator userValidator)
    {
        this.userRepository = userRepository;
        this.userValidator = userValidator;
    }
    public async Task AddUser(string name, string email, string password)
    {
        var user = new User()
        {
            Email = email,
            Password = password,
            Name = name
        };
        await userValidator.ValidateAndThrowAsync(user);
        await userRepository.Add(user);
    }

    public async Task DeleteUser(string id)
    {
        await userRepository.Delete(id);
    }

    public async Task<User> GetUserById(string id)
    {
        return await userRepository.GetById(id);
    }

  

    public async Task UpdateUser(string id, string name, string email, string password)
    {
        var user = await userRepository.GetById(id);

        user.Name = name;
        user.Email = email;
        user.Password = password;
        await userValidator.ValidateAndThrowAsync(user);
        await userRepository.Update(user);
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await userRepository.GetAllUsers();
    }
}
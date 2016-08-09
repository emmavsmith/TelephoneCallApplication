using System;
using System.Collections.Generic;
using AutoMapper;
using MPD.Interviews.Domain;
using MPD.Interviews.Interfaces.Logging;
using MPD.Interviews.Interfaces.Repositories;
using MPD.Interviews.WebApplication.Services.Interfaces;
using MPD.Interviews.WebApplication.ViewModels;

namespace MPD.Interviews.WebApplication.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, ILogger logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public UserViewModel GetUser(int id)
        {
            try
            {
                var user = _repository.Get(id);
                return _mapper.Map<UserViewModel>(user);
            }
            catch (Exception ex)
            {
                _logger.Error($"Error retrieving user with id {id}. Error: {ex.Message}", ex);
                return null;
            }
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            try
            {
                var users = _repository.GetAll();
                return _mapper.Map<IEnumerable<UserViewModel>>(users);
            }
            catch (Exception ex)
            {
                _logger.Error($"Error retrieving all users. Error: {ex.Message}", ex);
                return null;
            }
        }
    }
}
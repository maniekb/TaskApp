using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskApp.Domain.Entities;
using TaskApp.Domain.Repositories;
using TaskApp.Infrastructure.DTO;

namespace TaskApp.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(string firstname, string lastname)
        {
            var user = new User(firstname, lastname);
            await _userRepository.AddAsync(user);
        }

        public async Task<List<UserDTO>> BrowseAsync()
        {
            var users = await _userRepository.BrowseAsync();
            return _mapper.Map<List<User>, List<UserDTO>>(users);
        }

        public async Task DeleteAsync(int userId)
        {
            var user = await _userRepository.GetAsync(userId);
            await _userRepository.DeleteAsync(user);
        }

        public async Task<UserDTO> GetAsync(int userId)
        {
            var user = await _userRepository.GetAsync(userId);

            return _mapper.Map<User, UserDTO>(user);
        }

        public async Task UpdateAsync(int userId, string firstname, string lastname)
        {
            var user = await _userRepository.GetAsync(userId);
            user.FirstName = firstname;
            user.LastName = lastname;

            await _userRepository.UpdateAsync(user);
        }
    }
}

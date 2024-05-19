using AutoMapper;
using Innovative.Backend.Data.Context;
using Innovative.Backend.Data.Dtos;
using Innovative.Backend.Interfaces;
using Innovative.Backend.Models;
using Innovative.Backend.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Innovative.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IGenericRepository<Client> _repository;
        private readonly IMapper _mapper;

        public ClientsController(IGenericRepository<Client> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllClients")]
        public async Task<IActionResult> GetAllClientsAsync()
        {
            var clients = await _repository.GetAllAsync();
            if (clients is not null)
            {
                var result = _mapper.Map<IReadOnlyList<Client>, IReadOnlyList<ListingClientDo>>((IReadOnlyList<Client>)clients);
                return Ok(result);
            }
                
            return NotFound("No Users Found");
        }
        [HttpGet]
        [Route("GetClientById/{id}")]
        public async Task<IActionResult> GetClientByIdAsync(int id)
        {
            var client = await _repository.GetByIdAsync(id);
            if (client is not null)
            {
                var result = _mapper.Map<Client, ListingClientDo>(client);
                return Ok(result);
            }
               
            return NotFound("No User Found");
        }
        [HttpPost]
        [Route("AddClient")]
        public async Task<IActionResult> AddClientAsync(AddClientDto clientDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var client = _mapper.Map<Client>(clientDto);
                    await _repository.AddAsync(client);
                   return Ok(client);
                    
                }
                return BadRequest($"Model is not Valid {clientDto}");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateClient")]
        public async Task<ActionResult> UpdateCategory(UpdateClientDto clientDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingClient = await _repository.GetByIdAsync(clientDto.Id);
                    if (existingClient is not null)
                    {
                        _mapper.Map(clientDto, existingClient);
                        await _repository.UpdateAsync(clientDto.Id, existingClient);
                        return Ok();
                    }
                    return BadRequest($"Client Not Found, Id {clientDto.Id} is incorrect");
                }
                return BadRequest("Model is not Valid");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        [Route("DeleteClient/{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var clientToDelete = await _repository.GetByIdAsync(id);
                    if (clientToDelete is not null)
                    {
                        await _repository.DeleteAsync(id);
                        return Ok($"Client {clientToDelete.Name} deleted Successfully!");
                    }
                    return BadRequest($"Client Not Found, Id {id} is incorrect");
                }
                return BadRequest("Model is not Valid");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;
using System.Configuration;
using System.Numerics;
using System.Data.SqlClient;
using Microsoft.Extensions.Primitives;
using Dapper;
using SqlFunctions.Interface;

namespace SqlFunctions
{
    public class Clients
    {

        private readonly IClientRepository _clientRepository;
        public Clients(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        [FunctionName("GetAllClients")]
        public async Task<IActionResult> GetAllClients(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                Console.WriteLine(req.Body.ToString(), log);
                var clients = await _clientRepository.GetAllClients();
                return new OkObjectResult(clients);
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return new BadRequestResult();
            }
        }

        [FunctionName("GetClientById")]
        public async Task<IActionResult> GetClientById(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log)
        {
            string id = req.Query["id"];
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            id = id ?? data?.id;
            try
            {
                var schools = await _clientRepository.GetClientById(Int32.Parse(id));
                return new OkObjectResult(schools);
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return new BadRequestResult();
            }
        }

        [FunctionName("GetClientsByFirstName")]
        public async Task<IActionResult> GetClientsByFirstName(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log)
        {
            string firstName = req.Query["first_name"];
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            firstName = firstName ?? data?.firstName;
            try
            {
                var schools = await _clientRepository.GetClientsByFirstName(firstName);
                return new OkObjectResult(schools);
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return new BadRequestResult();
            }
        }

        [FunctionName("GetClientsByLastName")]
        public async Task<IActionResult> GetClientsByLastName(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log)
        {
            string lastName = req.Query["last_name"];
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            lastName = lastName ?? data?.lastName;
            try
            {
                var schools = await _clientRepository.GetClientsByLastName(lastName);
                return new OkObjectResult(schools);
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return new BadRequestResult();
            }
        }

        [FunctionName("GetClientsByEmail")]
        public async Task<IActionResult> GetClientsByEmail(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log)
        {
            string email = req.Query["email"];
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            email = email ?? data?.email;
            try
            {
                var schools = await _clientRepository.GetClientsByEmail(email);
                return new OkObjectResult(schools);
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return new BadRequestResult();
            }
        }

        [FunctionName("GetClientsByIpAddress")]
        public async Task<IActionResult> GetClientsByIpAddress(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log)
        {
            string ipAddress = req.Query["ip_address"];
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            ipAddress = ipAddress ?? data?.ipAddress;
            try
            {
                var schools = await _clientRepository.GetClientsByIpAddress(ipAddress);
                return new OkObjectResult(schools);
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return new BadRequestResult();
            }
        }

    }
}

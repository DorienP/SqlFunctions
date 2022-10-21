using Dapper;
using SqlFunctions.Context;
using SqlFunctions.Data.Entities;
using SqlFunctions.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlFunctions.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientContext _ClientContext;
        public ClientRepository(ClientContext clientContext)
        {
            _ClientContext = clientContext;
        }

        async Task<IEnumerable<Client>> IClientRepository.GetAllClients()
        {
            var query = "SELECT * FROM Clients ORDER By id";
            using
            var con = _ClientContext.CreateConnection();
            var client = await con.QueryAsync<Client>(query);
            return client.ToList();
        }

        async Task<Client> IClientRepository.GetClientById(int id)
        {
            var query = "SELECT * FROM Clients Where id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            using var con = _ClientContext.CreateConnection();
            var client = await con.QueryFirstOrDefaultAsync<Client>(query, parameters);
            return client;
        }

        async Task<IEnumerable<Client>> IClientRepository.GetClientsByFirstName(string firstName)
        {
            var query = "SELECT * FROM Clients WHERE CONTAINS(first_name, @FirstName)";

            var parameters = new DynamicParameters();
            parameters.Add("FirstName", firstName, DbType.String);

            using var con = _ClientContext.CreateConnection();
            var client = await con.QueryAsync<Client>(query, parameters);
            return client;
        }

        async Task<IEnumerable<Client>> IClientRepository.GetClientsByLastName(string lastName)
        {
            var query = "SELECT * FROM Clients WHERE CONTAINS(last_name, @LastName)";

            var parameters = new DynamicParameters();
            parameters.Add("LastName", lastName, DbType.String);

            using var con = _ClientContext.CreateConnection();
            var client = await con.QueryAsync<Client>(query, parameters);
            return client;
        }

        async Task<IEnumerable<Client>> IClientRepository.GetClientsByEmail(string email)
        {
            var query = "SELECT * FROM Clients WHERE CONTAINS(email, @Email)";

            var parameters = new DynamicParameters();
            parameters.Add("Email", email, DbType.String);

            using var con = _ClientContext.CreateConnection();
            var client = await con.QueryAsync<Client>(query, parameters);
            return client;
        }

        async Task<IEnumerable<Client>> IClientRepository.GetClientsByIpAddress(string ipAddress)
        {
            var query = "SELECT * FROM Clients WHERE CONTAINS(ip_address, @IpAddress)";

            var parameters = new DynamicParameters();
            parameters.Add("IpAddress", ipAddress, DbType.String);

            using var con = _ClientContext.CreateConnection();
            var client = await con.QueryAsync<Client>(query, parameters);
            return client;
        }

    }
}

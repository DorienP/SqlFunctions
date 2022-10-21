using SqlFunctions.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlFunctions.Interface
{
	public interface IClientRepository
	{
		Task<IEnumerable<Client>> GetAllClients();
		Task<Client> GetClientById(int id);
		Task<IEnumerable<Client>> GetClientsByFirstName(string firstName);
		Task<IEnumerable<Client>> GetClientsByLastName(string lastName);
		Task<IEnumerable<Client>> GetClientsByEmail(string email);
		Task<IEnumerable<Client>> GetClientsByIpAddress(string ipAddress);
	}
}

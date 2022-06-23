using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using DataTransferObject;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
        public class ClienteController
    {
        [HttpGet("TraerClientes")]
        public List<ClientesDTO> TraeclientesDTO()
        {
            IEnumerable<ClientesDTO> LC; 
            ClientesBL clientesBL = new ClientesBL();
            LC = clientesBL.GetAll();
            return LC.ToList();
            
        }


    }
}

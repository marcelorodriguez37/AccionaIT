using Domain.Models;
using Dominio.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application
{
    public class ProvinceService: IProvinceService
    {
        private readonly ILogger<ProvinceService> _logger;
        public ProvinceService(ILogger<ProvinceService> logger) {
            _logger = logger;
        }
        
        public LoginRSDto Login(LoginRQDto login)
        {
            LoginRSDto loginRs = new LoginRSDto();
            if (login.User.Equals("AccionaIT")) 
            { 
                loginRs.Menssage = "El usuario se logueo correctamente";
                loginRs.Success = true;
                _logger.LogInformation("Logueo exitoso");
            }
            else
            {
                loginRs.Menssage = "Los datos ingresados son erroneos";
                loginRs.Success = false;
            }
            return loginRs;
        }

        public async Task<ProvinceRSDto> ProvinceDate(string provinceName)
        {   
            string url = "https://apis.datos.gob.ar/georef/api/provincias?nombre="+provinceName;
            ResponseApi response = null;
            try
            {
                using (var http = new HttpClient())
                {
                    var datosGob = await http.GetStringAsync(url);
                    response = JsonSerializer.Deserialize<ResponseApi>(datosGob);
                }
            }
            catch (Exception ex) {
                _logger.LogError("Error al obtener la información de la provincia.", ex.Message);
            }

            ProvinceRSDto result = new ProvinceRSDto();
            if (response != null && response.provincias.Count() > 0) {
                result.Message = "Latitud y longuitud obtenidos";
                result.Lat = response.provincias[0].centroide.lat.ToString();
                result.Long = response.provincias[0].centroide.lon.ToString();
                _logger.LogInformation("Se obtuvo correctamente la informacion de la provincia");
            }
            else{
                result.Message = "La provincia no existe";
            }

            return result;
        }

    }
}

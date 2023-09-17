using Microsoft.EntityFrameworkCore;
using NeoSmart.Backend.Services;
using NeoSmart.Shared.Entities;
using NeoSmart.Shared.Responses;
using System.Data;

namespace NeoSmart.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IApiService _apiService;

        public SeedDb(DataContext context, IApiService apiService)
        {
            _context = context;
            _apiService = apiService;
        }



        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckRolesAsync();
            await CheckUsersAsync();
            await CheckPositionsAsync();
            await CheckThemesAsync();
            await CheckCapacitationsAsync();
            await ChecCoachingskAsync();
        }

        private async Task ChecCoachingskAsync()
        {
            if (!_context.Coachings.Any())
            {
                _context.Coachings.Add(new Coaching { Name = "Entrenamiento seguridad y salud ocupacional", PositionId=1 });
                _context.Coachings.Add(new Coaching { Name = "Entrenamiento Informatica", PositionId = 1 });
                _context.Coachings.Add(new Coaching { Name = "Entrenamiento Administración general", PositionId = 1 });
                _context.Coachings.Add(new Coaching { Name = "Entrenamiento Cartera", PositionId = 1 });
                _context.Coachings.Add(new Coaching { Name = "Entrenamiento Seguridad fisica", PositionId = 1 });
                _context.Coachings.Add(new Coaching { Name = "Entrenamiento Mercadeo y ventas", PositionId = 1 });
                _context.Coachings.Add(new Coaching { Name = "Entrenamiento Producción polimerización", PositionId = 1 });
                _context.Coachings.Add(new Coaching { Name = "Entrenamiento Operatividad SST", PositionId = 1 });
                _context.Coachings.Add(new Coaching { Name = "Entrenamiento Riesgos SST", PositionId = 1 });
                _context.Coachings.Add(new Coaching { Name = "Entrenamiento Producción Agroquimicos", PositionId = 1 });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCapacitationsAsync()
        {
            if (!_context.Capacitations.Any())
            {
                _context.Capacitations.Add(new Capacitation { Name = "Seguridad en alturas" });
                _context.Capacitations.Add(new Capacitation { Name = "Excel" });
                _context.Capacitations.Add(new Capacitation { Name = "Indunción corportativa" });
                _context.Capacitations.Add(new Capacitation { Name = "Reucados" });
                _context.Capacitations.Add(new Capacitation { Name = "Ingreso al parqueadero" });
                _context.Capacitations.Add(new Capacitation { Name = "Servicio al cliente" });
                _context.Capacitations.Add(new Capacitation { Name = "Manejo de quimicos" });
                _context.Capacitations.Add(new Capacitation { Name = "Maejo de extintores" });
                _context.Capacitations.Add(new Capacitation { Name = "Manejo de arnes" });
                _context.Capacitations.Add(new Capacitation { Name = "Manejo de productos agricolas" });

                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckThemesAsync()
        {
            if (!_context.Themes.Any())
            {
                _context.Themes.Add(new Theme { Name = "Seguridad en el trabajo" });
                _context.Themes.Add(new Theme { Name = "Agilidad" });
                _context.Themes.Add(new Theme { Name = "Gestión del cambio" });
                _context.Themes.Add(new Theme { Name = "Fomento de la confianza" });
                _context.Themes.Add(new Theme { Name = "Liderando a través de culturas" });
                _context.Themes.Add(new Theme { Name = "Menejo de  " });
                _context.Themes.Add(new Theme { Name = "Manejo del tiempo" });
                _context.Themes.Add(new Theme { Name = "Comunicación" });
                _context.Themes.Add(new Theme { Name = "Liderazgo" });
                _context.Themes.Add(new Theme { Name = "Organización" });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckPositionsAsync()
        {
            if (!_context.Positions.Any())
            {
                _context.Positions.Add(new Position { Name = "Coordinador SST" });
                _context.Positions.Add(new Position { Name = "Auditor financiero" });
                _context.Positions.Add(new Position { Name = "Ingeniero quimico" });
                _context.Positions.Add(new Position { Name = "Gerente" });
                _context.Positions.Add(new Position { Name = "Servicios de aseo" });
                _context.Positions.Add(new Position { Name = "Ingeniero de sistemas" });
                _context.Positions.Add(new Position { Name = "Contador publico" });
                _context.Positions.Add(new Position { Name = "Auxiliar contable" });
                _context.Positions.Add(new Position { Name = "Gerente sucursal girardota" });
                _context.Positions.Add(new Position { Name = "Gerente sucursal envigado" });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckRolesAsync()
        {
            if (!_context.Roles.Any())
            {
                _context.Roles.Add(new Role { Name = "Administrador" });
                _context.Roles.Add(new Role { Name = "Gerente" });
                _context.Roles.Add(new Role { Name = "Lider" });
                _context.Roles.Add(new Role { Name = "Capacitador" });
                _context.Roles.Add(new Role { Name = "Empleado" });
                await _context.SaveChangesAsync();
            }
        }


        private async Task CheckUsersAsync()
        {
            if (!_context.Users.Any())
            {
                _context.Users.Add(new User { Document="1234", FirstName="primer nombre",LastName="apellidos",Email="prueba1@gmail.com",CityId=1 });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                var responseCountries = await _apiService.GetAsync<List<CountryResponse>>("/v1", "/countries");
                if (responseCountries.WasSuccess)
                {
                    var countries = responseCountries.Result!;
                    foreach (var countryResponse in countries)
                    {
                        var country = await _context.Countries.FirstOrDefaultAsync(c => c.Name == countryResponse.Name!)!;
                        if (country == null)
                        {
                            country = new() { Name = countryResponse.Name!, States = new List<State>() };
                            var responseStates = await _apiService.GetAsync<List<StateResponse>>("/v1", $"/countries/{countryResponse.Iso2}/states");
                            if (responseStates.WasSuccess)
                            {
                                var states = responseStates.Result!;
                                foreach (var stateResponse in states!)
                                {
                                    var state = country.States!.FirstOrDefault(s => s.Name == stateResponse.Name!)!;
                                    if (state == null)
                                    {
                                        state = new() { Name = stateResponse.Name!, Cities = new List<City>() };
                                        var responseCities = await _apiService.GetAsync<List<CityResponse>>("/v1", $"/countries/{countryResponse.Iso2}/states/{stateResponse.Iso2}/cities");
                                        if (responseCities.WasSuccess)
                                        {
                                            var cities = responseCities.Result!;
                                            foreach (var cityResponse in cities)
                                            {
                                                if (cityResponse.Name == "Mosfellsbær" || cityResponse.Name == "Șăulița")
                                                {
                                                    continue;
                                                }
                                                var city = state.Cities!.FirstOrDefault(c => c.Name == cityResponse.Name!)!;
                                                if (city == null)
                                                {
                                                    state.Cities.Add(new City() { Name = cityResponse.Name! });
                                                }
                                            }
                                        }
                                        if (state.CitiesNumber > 0)
                                        {
                                            country.States.Add(state);
                                        }
                                    }
                                }
                            }
                            if (country.StatesNumber > 0)
                            {
                                _context.Countries.Add(country);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                }
            }
        }
    }
}

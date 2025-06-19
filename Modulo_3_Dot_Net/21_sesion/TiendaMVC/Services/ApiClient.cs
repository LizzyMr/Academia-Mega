using System.Net.Http.Headers;
using TiendaMVC.Models;

namespace TiendaMVC.Services
{
    public class ApiClient : IProductoApiService 
    {
        private readonly HttpClient _http;
        private readonly IHttpContextAccessor _context;

        public ApiClient(HttpClient http, IHttpContextAccessor context)
        {
            _http = http;
            _context = context;

            // Si es que hay un token de sesion, lo incluimos en cada peticion
            var token = _context.HttpContext!.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public Task<List<Producto>> GetProductosAsync()
            => _http.GetFromJsonAsync<List<Producto>>("api/productos")!;

        // Autenticación
        public async Task<bool> LoginAsync(User user)
        {
            var response = await _http.PostAsJsonAsync("/api/auth/login", user);
            if (!response.IsSuccessStatusCode) return false;
            var obj = await response.Content.ReadFromJsonAsync<TokenResponse>();
            _context.HttpContext!.Session.SetString("JWToken", obj!.Token);
            return true;
        }

        public async Task<bool> RegisterAsync(User user)
        {
            var response = await _http.PostAsJsonAsync("api/auth/registro", user);
            if (!response.IsSuccessStatusCode) return false;
            var obj = await response.Content.ReadFromJsonAsync<TokenResponse>();
            _context.HttpContext!.Session.SetString("JWToken", obj!.Token);
            return true;
        }

        public async Task<Producto?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Producto>($"api/productos/{id}");
        }

        public async Task<Producto?> CreateAsync(Producto producto)
        {
            var response = await _http.PostAsJsonAsync("api/productos", producto);
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<Producto>();
        }

        public async Task<bool> UpdateAsync(int id, Producto producto)
        {
            var response = await _http.PutAsJsonAsync($"api/productos/{id}", producto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/productos/{id}");
            return response.IsSuccessStatusCode;
        }

    }

    public class TokenResponse { public string Token { get; set; } = ""; }

}
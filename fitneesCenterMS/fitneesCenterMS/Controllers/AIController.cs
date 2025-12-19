using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace fitneesCenterMS.Controllers
{
    [Authorize]
    public class AIController : Controller
    {
        
        private const string ApiKey = "****************";

        
        private const string ApiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key=";

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAdvice(int age, int weight, int height, string goal)
        {
            try
            {
                
                string prompt = $"Yaş: {age}, Kilo: {weight}, Boy: {height}, Hedef: {goal}. Bu kişiye HTML formatında kısa spor ve beslenme tavsiyesi ver.";

                var payload = new { contents = new[] { new { parts = new[] { new { text = prompt } } } } };
                string jsonPayload = JsonSerializer.Serialize(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.PostAsync(ApiUrl + ApiKey, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var jsonNode = JsonNode.Parse(responseString);
                        string aiResponse = jsonNode?["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString();

                        if (!string.IsNullOrEmpty(aiResponse))
                        {
                            
                            return Content(aiResponse.Replace("```html", "").Replace("```", ""), "text/html");
                        }
                    }
                }
            }
            catch
            {
            }

            string fakeAdvice = $@"
                <div class='alert alert-warning'>⚠️ Not: AI Bağlantısı kurulamadı, offline moddasınız.</div>
                <h3>Merhaba! Senin İçin Hazırladığım Program:</h3>
                <p><strong>Profil Analizi:</strong> {age} yaşında, {weight}kg ve {height}cm boyundasın. VKE değerin yaklaşık: {(weight / ((height / 100.0) * (height / 100.0))):F1}</p>
                <p><strong>Hedefin:</strong> {goal}</p>
                <hr/>
                <h4>🏃‍♂️ Egzersiz Planı:</h4>
                <ul>
                    <li>Haftada 3 gün tüm vücut (Full Body) antrenmanı yapmalısın.</li>
                    <li>Her antrenman öncesi 10 dakika tempolu yürüyüş ile ısın.</li>
                    <li>Squats, Push-ups ve Plank hareketlerine odaklan.</li>
                </ul>
                <h4>🥗 Beslenme İpuçları:</h4>
                <ul>
                    <li>Günde en az 2.5 litre su içmeyi ihmal etme.</li>
                    <li>Protein ağırlıklı beslen (Yumurta, tavuk, balık).</li>
                    <li>Şekerli içeceklerden uzak dur.</li>
                </ul>
                <div class='mt-3'><em>Başarılar dilerim! 💪</em></div>
            ";

            await Task.Delay(1000); 
            return Content(fakeAdvice, "text/html");
        }
    }
}
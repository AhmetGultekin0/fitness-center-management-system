using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fitneesCenterMS.Controllers
{
    [Authorize]
    public class AIController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAdvice(int age, int weight, int height, string goal)
        {
            string advicePart = "";
            string imagePromptPart = "fitness gym workout cinematic"; 

            try
            {
                

                string systemPrompt = $@"
                    Rolün: Profesyonel ve motive edici bir Fitness Koçu.
                    Kullanıcı Bilgileri: Yaş {age}, Kilo {weight}, Boy {height}, Hedef: '{goal}'.
                    
                    Lütfen cevabı TAM OLARAK şu formatta ver (Araya ||| işareti koyman zorunlu):
                    
                    [Buraya HTML formatında (<p>, <ul> etiketleri kullanarak) Türkçe kısa bir antrenman ve beslenme tavsiyesi yaz]
                    |||
                    [Buraya kullanıcının hedefi için İngilizce kısa görsel promptu yaz. Örn: muscular man in gym]
                    ";

                using (var httpClient = new HttpClient())
                {
                    var url = $"https://text.pollinations.ai/{Uri.EscapeDataString(systemPrompt)}?model=openai";

                    var responseString = await httpClient.GetStringAsync(url);

                    if (!string.IsNullOrEmpty(responseString))
                    {
                        var parts = responseString.Split("|||");

                        advicePart = parts[0].Trim();

                        if (parts.Length > 1)
                        {
                            imagePromptPart = parts[1].Trim();
                        }
                    }
                }
            }
            catch
            {
                advicePart = "<div class='alert alert-warning'>Bağlantı zayıf ama pes etmek yok!</div><p>Bol protein, düzenli uyku ve sıkı antrenman. Halledersin! 💪</p>";
            }

            return Json(new { advice = advicePart, imagePrompt = imagePromptPart });
        }
    }
}
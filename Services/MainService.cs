using Newtonsoft.Json;
using StringPorject.Models;

namespace StringPorject.Services
{
    public class MainService
    {
        public LogResponse SaveLog(Log request)
        {
            var response = new LogResponse();
            try
            {
                if (request != null)
                {
                    var listOfLog = new List<Log>();
                    var filePath = Path.Combine("SaveFiles","Logs.json");
                    if (File.Exists(filePath))//Json dosyasının varlığı kontrol edildi
                    {
                        var file = File.ReadAllText(filePath);
                        listOfLog = JsonConvert.DeserializeObject<List<Log>>(file);
                    }
                    listOfLog.Add(request);
                    var json = JsonConvert.SerializeObject(listOfLog);
                    File.WriteAllText(filePath, json);
                    response.Data = request;
                    response.Success = true;
                }
                else
                {
                    response.Message = "Boş log kaydı tamamlanamaz";
                    response.Success = false;
                }

            }
            catch (Exception e)
            {
                response.Message = "Kaydedilirken hata oluştu" + e;
                response.Success = false;
            }
            return response;
        }


        public StringResponse SaveString(string[] request)
        {
            var response = new StringResponse();
            try
            {
                if (request != null)
                {
                    var filePath = Path.Combine("SaveFiles", "StringArray.json");
                    var json = JsonConvert.SerializeObject(request);
                    File.WriteAllText(filePath, json);
                    response.Data = request;
                    response.Success = true;
                }
                else
                {
                    response.Message = "Boş request kaydı tamamlanamaz";
                    response.Success = false;
                }

            }
            catch (Exception e)
            {
                response.Message = "Kaydedilirken hata oluştu" + e;
                response.Success = false;
            }
            return response;
        }


        public StringResponse ShowString()
        {
            var response = new StringResponse();
            try
            {
                var filePath = Path.Combine("SaveFiles", "StringArray.json");
                var json = File.ReadAllText(filePath);
                response.Data = JsonConvert.DeserializeObject<string[]>(json);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = "Kayıt okunurken hata oluştu" + e;
                response.Success = false;
            }
            return response;
        }


        public LogsResponse ShowLogs()
        {
            var response = new LogsResponse();
            try
            {
                var filePath = Path.Combine("SaveFiles", "Logs.json");
                var file = File.ReadAllText(filePath);
                var listOfLog = JsonConvert.DeserializeObject<List<Log>>(file);
                response.Data = listOfLog;
                response.Success = true;

            }
            catch (Exception e)
            {
                response.Message = "Kayıt okunurken hata oluştu" + e;
                response.Success = false;
            }
            return response;
        }
    }
}

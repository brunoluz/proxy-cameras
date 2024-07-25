using System.Text.Json;

namespace proxy_cameras
{
    public class CamerasConfiguration : ICamerasConfiguration
    {
        private ILogger<CamerasConfiguration> _logger;
        private readonly string _user;
        private readonly string _password;
        private readonly CameraSetting[] _cameraSettings;

        public CamerasConfiguration(ILogger<CamerasConfiguration> _logger)
        {
            string fileName = "camerasconfiguration.json";
            string jsontext = File.ReadAllText(fileName);
            JsonDocument json = JsonDocument.Parse(jsontext);

            _logger.LogInformation("loaded!");

            _user = json.RootElement.GetProperty("user").GetString();
            _password = json.RootElement.GetProperty("password").GetString();
            
            var cameraSettings = new List<CameraSetting>();
            foreach(JsonElement element in json.RootElement.GetProperty("cameras").EnumerateArray())
            {
                string name = element.GetProperty("name").GetString();
                string shortname = element.GetProperty("shortname").GetString();
                string url = element.GetProperty("url").GetString();

                cameraSettings.Add(new CameraSetting(name, shortname, url));
            }
            _cameraSettings = cameraSettings.ToArray();
        }

        public string User => _user;

        public string Password => _password;

        public CameraSetting[] CameraSettings => _cameraSettings;
    }
}

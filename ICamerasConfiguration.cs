namespace proxy_cameras
{
    public class CameraSetting(string name, string shortname, string url)
    {
        public string Name { get; } = name;

        public string Shortname { get; } = shortname;

        public string Url { get; } = url;
    }


    public interface ICamerasConfiguration
    {
        public string User { get; }
        public string Password { get; }

        public CameraSetting[] CameraSettings { get; }

    }
}

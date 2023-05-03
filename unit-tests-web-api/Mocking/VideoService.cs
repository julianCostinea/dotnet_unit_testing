using Newtonsoft.Json;

namespace unit_tests_web_api.Mocking;

public class VideoService
{
    private IFileReader _fileReader;
    private IVideoRepository _repository;

    //injecting with properties
    public IFileReader FileReader { get; set; }

    public VideoService()
    {
        FileReader = new FileReader();
    }

    public VideoService(IFileReader fileReader = null, IVideoRepository repository = null)
    {
        _fileReader = fileReader ?? new FileReader();
        // _repository = repository ?? new VideoRepository();
    }
    
    public string ReadVideoTitle()
    {
        var str = FileReader.Read("video.txt");
        var video = JsonConvert.DeserializeObject<Video>(str);
        if (video == null)
            return "Error parsing the video.";
        return video.Title;
    }

    // dependency injection with method parameters 
    // public string ReadVideoTitle(IFileReader fileReader)
    // {
    //     var str = fileReader.Read("video.txt");
    //     var video = JsonConvert.DeserializeObject<Video>(str);
    //     if (video == null)
    //         return "Error parsing the video.";
    //     return video.Title;
    // }

    public string GetUnprocessedVideosAsCsv()
    {
        var videoIds = new List<int>();

        var videos = _repository.GetUnprocessedVideos();
        foreach (var v in videos)
            videoIds.Add(v.Id);

        return String.Join(",", videoIds);
    }
}

public class Video
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsProcessed { get; set; }
}

// public class VideoContext : DbContext, IDisposable
// {
//     public DbSet<Video> Videos { get; set; }
//     public void Dispose()
//     {
//         throw new NotImplementedException();
//     }
// }
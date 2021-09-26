using Services.Model;

namespace Services.Services
{
    public interface IDirectoryService
    {
        FileNode GetAllNodes(string path);
    }
}

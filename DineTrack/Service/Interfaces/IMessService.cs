namespace DineTrack.Service.Interfaces
{
    public interface IMessService
    {
        public Task CreateMessAsync(string name, int hostelId,int managerId);

    }
}

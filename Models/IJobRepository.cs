namespace Mission08_0110.Models
{
    public interface IJobRepository
    {
        List<Job> Jobs { get; }

        public void AddJob(Job job);

        public void EditJob(Job job);

        public void DeleteJob(Job job);
    }
}

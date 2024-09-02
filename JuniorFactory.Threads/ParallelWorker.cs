namespace JuniorFactory.Threads
{
    internal class ParallelWorker
    {
        internal static void Run()
        {
            var jobs = new List<Job>();
            for (var i = 0; i < 10; i++)
            {
                jobs.Add(new Job() { Id = i + 1 });
            }

            if (false)
            {
                foreach (var job in jobs)
                {
                    Log("start job " + job.Id);
                    job.Calculate();
                    Log("complete job " + job.Id);
                }
            }
            if (false)
            {
                jobs.AsParallel().Select(job =>
                {
                    Log("start job " + job.Id);
                    job.Calculate();
                    Log("complete job " + job.Id);
                    return 1;
                }).ToList();
            }
            if (false)
            {
                Parallel.ForEach(jobs, new ParallelOptions { MaxDegreeOfParallelism = 2 }, (job) =>
                {

                    Log("start job " + job.Id);
                    job.Calculate();
                    Log("complete job " + job.Id);
                });
            }

            if (false)
            {
                foreach (var job in jobs)
                {
                    var th = new Thread(Test);
                    th.Start(job);
                }
            }

            Log("all jobs complete");
        }

        private static void Test(object? obj)
        {
            var job = obj as Job;
            Log("start job " + job.Id);
            job.Calculate();
            Log("complete job " + job.Id);
        }

        public class Job
        {
            public int Id { get; set; }
            public int Calculate()
            {
                Thread.Sleep(1000);
                Log($"process job {Id} [thread {Thread.CurrentThread.ManagedThreadId}]");
                return DateTime.Now.Millisecond;
            }
        }

        private static void Log(string message)
        {
            Console.WriteLine(DateTime.Now.ToString("mm:ss.fff ") + message);
        }
    }
}

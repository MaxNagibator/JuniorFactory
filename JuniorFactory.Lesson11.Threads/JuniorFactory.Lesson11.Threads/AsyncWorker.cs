namespace JuniorFactory.Lesson11.Threads
{
    internal class AsyncWorker
    {
        internal static async Task Run()
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
                    await job.Calculate();
                    Log("complete job " + job.Id);
                }
            }
            if (false)
            {
                var job1 = jobs[1].Calculate();
                var job2 = jobs[2].Calculate();
                Task.WaitAll(job1, job2);

                List<Task> tasks = new List<Task>();
                foreach (var job in jobs)
                {
                    var result = job.Calculate();
                    tasks.Add(result);
                }

                Task.WaitAll(tasks.ToArray());
            }

            if (false)
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                CancellationToken token = cts.Token;
                var task = jobs[0].CalculateWithToken(token);
                cts.Cancel();
                task.Wait();
                await task;
            }

            if (false)
            {
                Func<Task> action = async () => { Log("test"); await Task.Delay(1000); Log("test2"); };
                Action actionXXX = async () => { Log("testXXX"); await Task.Delay(500); Log("test2XXX"); };
                await Task.Run(actionXXX);
                await Task.Run(action);
                await Task.Run(Action1);
            }

            if (true)
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                CancellationToken token = cts.Token;

                List<Task> tasks = new List<Task>();
                foreach (var job in jobs)
                {
                    var result = job.CalculateWithToken(token);
                    tasks.Add(result);
                }

                await Task.Delay(500);
                cts.Cancel();
                Task.WaitAll(tasks.ToArray());
            }
            Log("all jobs complete");
        }

        public static async Task Action1()
        {
            Log("test"); await Task.Delay(1000); Log("test2");
        }

        public class Job
        {
            public int Id { get; set; }
            public async Task<int> Calculate()
            {
                Log($"process start job {Id} [thread {Thread.CurrentThread.ManagedThreadId}]");
                await Task.Delay(100 * Id);
                Log($"process finish job {Id} [thread {Thread.CurrentThread.ManagedThreadId}]");
                return DateTime.Now.Millisecond;
            }

            public async Task<int> CalculateWithToken(CancellationToken token)
            {
                if (false)
                {
                    token.ThrowIfCancellationRequested();
                }

                Log($"process start job {Id} [a] [thread {Thread.CurrentThread.ManagedThreadId}]");
                await Task.Delay(100* Id);

                if (token.IsCancellationRequested)
                {
                    Log($"process canceled job {Id} [thread {Thread.CurrentThread.ManagedThreadId}]");
                    return 0;
                }

                Log($"process start job {Id} [b] [thread {Thread.CurrentThread.ManagedThreadId}]");
                await Task.Delay(1000);

                Log($"process finish job {Id} [thread {Thread.CurrentThread.ManagedThreadId}]");
                return DateTime.Now.Millisecond;
            }
        }

        private static void Log(string message)
        {
            Console.WriteLine(DateTime.Now.ToString("mm:ss.fff ") + message);
        }
    }
}

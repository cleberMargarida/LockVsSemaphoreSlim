using BMark;

const int count = 2054;
object _lock = new object();
SemaphoreSlim slimSemaphore = new SemaphoreSlim(count, count);

ulong amountToRun = (ulong)(count - PerformanceTester.PreRunAmount - 2);

PerformanceTester.Run("lock", amountToRun, () => { lock (_lock) { } });
PerformanceTester.Run("SemaphoreSlim.WaitOne", amountToRun, () => { slimSemaphore.Wait(); });
PerformanceTester.Run("SemaphoreSlim.Release", amountToRun, () => { slimSemaphore.Release(); });

Console.WriteLine(PerformanceTester.GetResults());

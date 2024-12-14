namespace ProjetoRPG.Infra;

public static class AsyncHelper
{
    public static void FireAndForget(Task task, Action<Exception>? onError = null)
    {
        _ = Task.Run(async () =>
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        });
    }
}
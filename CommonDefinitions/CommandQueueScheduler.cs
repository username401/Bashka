using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonDefinitions
{
    //CommandQueueScheduler - класс, который управляет очередью команд.
    //BlockingCollection<Action> - используется для хранения команд. Она блокирует поток, если коллекция пуста, и разблокирует, когда в нее добавляется элемент.
    //CancellationTokenSource - используется для отмены выполнения команд.
    //EnqueueCommand - метод для добавления команд в очередь.
    //ProcessCommands - метод, который выполняет команды из очереди.
    //Stop - метод для остановки планировщика.
    public class CommandQueueScheduler
    {
        private readonly BlockingCollection<Action> _commandQueue = new BlockingCollection<Action>();
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public CommandQueueScheduler()
        {
            Task.Factory.StartNew(ProcessCommands, _cancellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        public void EnqueueCommand(Action command)
        {
            if (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                _commandQueue.Add(command);
            }
        }

        private void ProcessCommands()
        {
            foreach (var command in _commandQueue.GetConsumingEnumerable(_cancellationTokenSource.Token))
            {
                try
                {
                    command();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error executing command: {ex.Message}");
                }
            }
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
            _commandQueue.CompleteAdding();
        }
    }
}

using Autodesk.Revit.UI;
using NUnit.Framework;
using ricaun.Revit.UI.Tasks;
using System;
using System.Threading;
using System.Threading.Tasks;

[assembly: System.Reflection.AssemblyDescription("{\"TestAsync\":\"RevitTask\",\"TimeOut\":60.0}")]

namespace RevitTest.Sample
{
    public class Tests_RevitTask : RevitTaskBase
    {
        [Test]
        public async Task TestPostableCommand_NewProject()
        {
            await RevitTask.Run((uiapp) =>
            {
                uiapp.DialogBoxShowing += DialogBoxShowingForceClose;
                uiapp.PostCommand(RevitCommandId.LookupPostableCommandId(PostableCommand.NewProject));
            });

            await RevitTask.Run((uiapp) =>
            {
                uiapp.DialogBoxShowing -= DialogBoxShowingForceClose;
            });
        }

        private void DialogBoxShowingForceClose(object sender, Autodesk.Revit.UI.Events.DialogBoxShowingEventArgs e)
        {
            var uiapp = sender as UIApplication;
            uiapp.DialogBoxShowing -= DialogBoxShowingForceClose;
            Console.WriteLine($"DialogBoxShowing {e.DialogId}");
            e.OverrideResult((int)TaskDialogResult.Close);
        }
    }

    public class RevitTaskBase
    {
        protected IRevitTask RevitTask { get; private set; }

        [OneTimeSetUp]
        public void Initialize(Func<Func<UIApplication, object>, CancellationToken, Task<object>> revitTask)
        {
            RevitTask = new RevitTaskFuncService(revitTask);
        }

        public class RevitTaskFuncService : IRevitTask
        {
            private Func<Func<UIApplication, object>, CancellationToken, Task<object>> RevitTask;
            public RevitTaskFuncService(Func<Func<UIApplication, object>, CancellationToken, Task<object>> revitTask)
            {
                RevitTask = revitTask;
            }
            public async Task<TResult> Run<TResult>(Func<UIApplication, TResult> function, CancellationToken cancellationToken)
            {
                var result = await RevitTask.Invoke((uiapp) => { return function(uiapp); }, cancellationToken);

                if (result is TResult t)
                    return t;

                return default;
            }
        }
    }

    public class Tests_RevitTask_Parameters
    {
        [Test]
        public async Task RevitTaskNone0(Func<Action, Task> revitTask)
        {
            var result = false;
            await revitTask.Invoke(() => { result = true; });
            Assert.IsTrue(result);
        }
        [Test]
        public async Task RevitTaskNone1(Func<Action<UIApplication>, Task> revitTask)
        {
            var result = false;
            await revitTask.Invoke((uiapp) => { result = true; });
            Assert.IsTrue(result);
        }
        [Test]
        public async Task RevitTaskNone2(Func<Func<object>, Task<object>> revitTask)
        {
            var result = (bool)await revitTask.Invoke(() => { return true; });
            Assert.IsTrue(result);
        }
        [Test]
        public async Task RevitTaskNone3(Func<Func<UIApplication, object>, Task<object>> revitTask)
        {
            var result = (bool)await revitTask.Invoke((uiapp) => { return true; });
            Assert.IsTrue(result);
        }

        [Test]
        public async Task RevitTaskToken0(Func<Action, CancellationToken, Task> revitTask)
        {
            var result = false;
            await revitTask.Invoke(() => { result = true; }, CancellationToken.None);
            Assert.IsTrue(result);
        }
        [Test]
        public async Task RevitTaskToken1(Func<Action<UIApplication>, CancellationToken, Task> revitTask)
        {
            var result = false;
            await revitTask.Invoke((uiapp) => { result = true; }, CancellationToken.None);
            Assert.IsTrue(result);
        }
        [Test]
        public async Task RevitTaskToken2(Func<Func<object>, CancellationToken, Task<object>> revitTask)
        {
            var result = (bool)await revitTask.Invoke(() => { return true; }, CancellationToken.None);
            Assert.IsTrue(result);
        }
        [Test]
        public async Task RevitTaskToken3(Func<Func<UIApplication, object>, CancellationToken, Task<object>> revitTask)
        {
            var result = (bool)await revitTask.Invoke((uiapp) => { return true; }, CancellationToken.None);
            Assert.IsTrue(result);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICanPay.Abstractions
{
    public sealed class NotifyHub
    {
        private readonly INotifyHubHandler _hubHandler;
        private Func<HubOrder, Task> _successHandler;
        private Func<HubOrder, Task> _failHandler;
        private Func<IKeyValueProvider, Task> _beforeProcessHandler;
        private Func<HubOrder, Task> _afterProcessHandler;
        private Func<Exception, Task> _exceptionHandler;
        public NotifyHub(INotifyHubHandler hubHandler)
        {
            _hubHandler = hubHandler;
        }

        public NotifyHub WhenSuccess(Func<HubOrder, Task> deleget)
        {
            _successHandler = deleget;
            return this;
        }
        public NotifyHub WhenFail(Func<HubOrder, Task> deleget)
        {
            _failHandler = deleget;
            return this;
        }

        public NotifyHub WhenBeforeProcess(Func<IKeyValueProvider, Task> deleget)
        {
            _beforeProcessHandler = deleget;
            return this;
        }
        public NotifyHub WhenAfterProcess(Func<HubOrder, Task> deleget)
        {
            _afterProcessHandler = deleget;
            return this;
        }

        public NotifyHub WhenException(Func<Exception,Task> deleget)
        {
            _exceptionHandler = deleget;
            return this;
        }

        //[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public async Task ProcessAsync(HubOrder data)
        {
            // 首先检查,   成功和异常处理必须注册

            if (_successHandler == null)
            {
                throw new InvalidOperationException("No Success delegate registed");
            }
            if (_exceptionHandler == null)
            {
                throw new InvalidOperationException("No Exception delegate registed");
            }

            // before
            if(_beforeProcessHandler != null)
            {
                await _beforeProcessHandler(null);
            }

            try
            {
                var result = _hubHandler.Process(null);
                if (result.IsSuccess)
                {
                    await _successHandler(null);
                }
                else
                {
                    if (_failHandler != null)
                    {
                        await _failHandler(null);
                    }
                }
            }
            catch(Exception e)
            {
                await _exceptionHandler(e);
            }
            if(_afterProcessHandler != null)
            {
                await _afterProcessHandler(null);
            }
            


        }
    }
}

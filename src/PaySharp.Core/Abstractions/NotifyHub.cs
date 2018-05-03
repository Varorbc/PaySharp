using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySharp.Abstractions
{

    /// <summary>
    /// 通知适配器
    /// </summary>
    public sealed class NotifyHub
    {
        private readonly INotifyHubHandler _hubHandler;
        private Func<HubOrder, IKeyValueProvider, Task> _successHandler;
        private Func<HubOrder, IKeyValueProvider, Task> _failHandler;
        private Func<IKeyValueProvider, Task> _beforeProcessHandler;
        private Func<HubOrder, IKeyValueProvider, Task> _afterProcessHandler;
        private Func<Exception, IKeyValueProvider, Task> _exceptionHandler;

        /// <summary>
        /// 通过一个 <see cref="INotifyHubHandler"/> 来实例化 该适配器
        /// </summary>
        /// <param name="hubHandler">要用来处理的通知处理器</param>
        public NotifyHub(INotifyHubHandler hubHandler)
        {
            _hubHandler = hubHandler;
        }

        /// <summary>
        /// 一次性添加整个处理流程
        /// </summary>
        /// <param name="handler">一个拥有所有处理流程的类的实例</param>
        /// <returns>返回配置的<see cref="NotifyHub"/></returns>
        public NotifyHub UseUserHandler(IUserHandler handler)
        {
            _beforeProcessHandler = handler.OnProcessingAsync;
            _successHandler = handler.OnSuccessedAsync;
            _failHandler = handler.OnFailedAsync;
            _exceptionHandler = handler.OnExceptionAsync;
            _afterProcessHandler = handler.OnProcessedAsync;
            return this;
        }
        
        //[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public async Task ProcessAsync(IKeyValueProvider valueProvider)
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
                await _beforeProcessHandler(valueProvider);
            }

            try
            {
                var result = await _hubHandler.ProcessAsync(valueProvider);
                if (result.IsSuccess)
                {
                    await _successHandler(result.Data,valueProvider);
                }
                else
                {
                    if (_failHandler != null)
                    {
                        await _failHandler(result.Data,valueProvider);
                    }
                }

                if (_afterProcessHandler != null)
                {
                    await _afterProcessHandler(result.Data,valueProvider);
                }
            }
            catch(Exception e)
            {
                await _exceptionHandler(e,valueProvider);
            }
            
        }
    }
}

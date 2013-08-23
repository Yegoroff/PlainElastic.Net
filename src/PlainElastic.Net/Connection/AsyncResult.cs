using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlainElastic.Net
{
	public class AsyncResult : IAsyncResult
	{
		private AsyncCallback _cb;

		public object AsyncState
		{
			get;
			private set;
		}

		private System.Threading.ManualResetEvent _asyncWaitHandle;
		public System.Threading.WaitHandle AsyncWaitHandle
		{
			get
			{
				if (_asyncWaitHandle == null)
					_asyncWaitHandle = new System.Threading.ManualResetEvent(IsCompleted);
				return _asyncWaitHandle;
			}
		}

		public bool CompletedSynchronously
		{
			get;
			private set;
		}

		public bool IsCompleted
		{
			get;
			private set;
		}

		public object Result { get; private set; }

		internal Exception Error { get { return Result as Exception; } }

		public static AsyncResult CreateAndStart(AsyncCallback cb, object state)
		{
			var rval = new AsyncResult();
			rval.Start(cb, state);
			return rval;
		}

		private void Start(AsyncCallback cb, object state)
		{
			_cb = cb;
			AsyncState = state;
			CompletedSynchronously = IsCompleted = false;
			Result = null;
			if (_asyncWaitHandle != null)
			{
				_asyncWaitHandle.Dispose();
				_asyncWaitHandle = null;
			}
		}

		internal void End(object result, bool completed_synchronously = false)
		{
			if (!IsCompleted)
			{
				Result = result;
				CompletedSynchronously = completed_synchronously;
				IsCompleted = true;
				try { if (_cb != null) _cb(this); }
				finally { if (_asyncWaitHandle != null) _asyncWaitHandle.Set(); }
			}
			else throw new Exception("Double end invocation", result as Exception);
		}
	}
}

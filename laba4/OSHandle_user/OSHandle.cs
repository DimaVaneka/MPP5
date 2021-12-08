using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace OSHandleTest
{
    public class OSHandle : IDisposable
    {
        [DllImport("Kernel32.dll",
            EntryPoint = "CloseHandle",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern bool CloseHandle(IntPtr handle);//Функция CloseHandle закрывает дескриптор открытого объекта.

        private bool isDisposed; //Возвращает значение, указывающее, был ли удален элемент управления.

        public IntPtr handle { get; set; }

        public OSHandle(IntPtr handle)
        {
            this.handle = handle;
            isDisposed = false;
        }

        public void Dispose()
        {
            Dispose(true);
            // подавляем финализацию
            GC.SuppressFinalize(this);//GC.SuppressFinalize не позволяет системе выполнить метод Finalize для данного объекта.
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    // Освобождаем управляемые ресурсы
                    CloseHandle(handle);
                    handle = IntPtr.Zero;
                }
                // освобождаем неуправляемые объекты


                isDisposed = true;
            }
        }

        ~OSHandle()
        {
            Dispose(false);
        }
    }
}

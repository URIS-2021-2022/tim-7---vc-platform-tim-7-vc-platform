using System;
using System.IO;
using VirtoCommerce.Platform.Core.TransactionFileManager;

namespace VirtoCommerce.Platform.Data.TransactionFileManager.Operations
{
    /// <summary>
    /// Class that contains common code for those rollbackable file operations which need
    /// to backup a single file and restore it when Rollback() is called.
    /// </summary>
    abstract class SingleFileOperation : IRollbackableOperation, IDisposable
    {
        protected readonly string path;
        protected string backupPath;
        // tracks whether Dispose has been called
        private bool disposed;

        protected SingleFileOperation(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Disposes the resources used by this class.
        /// </summary>
        ~SingleFileOperation()
        {
            Dispose(false);
        }

        public abstract void Execute();

        public void Rollback()
        {
            if (backupPath != null)
            {
                string directory = Path.GetDirectoryName(path);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                File.Copy(backupPath, path, true);
            }
            else
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the resources of this class.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (backupPath != null)
                {
                    FileInfo fi = new FileInfo(backupPath);
                    if (fi.IsReadOnly)
                    {
                        fi.Attributes = FileAttributes.Normal;
                    }
                    File.Delete(backupPath);
                }

                disposed = true;
            }
        }
    }
}

using System;
using System.IO.Compression;
using System.IO;

namespace iQuest.VendingMachine.Reports
{
    internal class ZippedReportFileStream : Stream, IDisposable
    {
        private readonly MemoryStream stream;

        public override bool CanRead => (bool)(stream?.CanRead);

        public override bool CanSeek => (bool)(stream?.CanSeek);

        public override bool CanWrite => (bool)(stream?.CanWrite);

        public override long Length => (long)(stream?.Length);

        public override long Position { get => (long)(stream?.Position); set => stream.Position = value; }

        public ZippedReportFileStream(MemoryStream stream)
        {
            this.stream = stream ?? throw new ArgumentNullException(nameof(stream));
        }

        public void Zip(string zipFile)
        {
            using FileStream fileStream = new FileStream(zipFile, FileMode.Create);
            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(fileStream);
        }

        public StreamWriter CreateEntry(string fileNameInArchive)
        {
            using (ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Create, true))
            {
                var file = archive.CreateEntry(fileNameInArchive);

                using Stream entryStream = file.Open();
                using StreamWriter streamWriter = new StreamWriter(entryStream);

                return streamWriter;
            }
        }

        public override void Flush()
        {
            stream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return (int)(stream?.Read(buffer, offset, count));
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return (long)(stream?.Seek(offset, origin));
        }

        public override void SetLength(long value)
        {
            stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            stream.Write(buffer, offset, count);
        }

        ~ZippedReportFileStream()
        {
            stream?.Dispose();
        }
    }
}

using System;
using System.IO;
using System.Threading.Tasks;

namespace IO;

public partial class FileCopy
{
    public static void Copy(string sourceFilename,
      string destinationFilename)
    {
        using var inputStream = File.OpenRead(sourceFilename);
        using var outputStream = File.Create(destinationFilename);
        while (true)
        {
            int b = inputStream.ReadByte();
            if (b < 0)
            {
                break;
            }
            outputStream.WriteByte((byte)b);
        }
    }

    public static void CopyBuffered(string sourceFilename,
      string destinationFilename, int bufferSize)
    {

        using var inputStream = File.OpenRead(sourceFilename);
        using var outputStream = File.Create(destinationFilename);
        var buffer = new byte[bufferSize];
        while (true)
        {
            int readBytes = inputStream.Read(buffer, 0, bufferSize);
            if (readBytes == 0)
            {
                break;
            }
            outputStream.Write(buffer, 0, readBytes);
        }
    }

    public async static Task CopyAsync(string sourceFilename,
    string destinationFilename, int bufferSize)
    {

        using var inputStream = File.OpenRead(sourceFilename);
        using var outputStream = File.Create(destinationFilename);
        var buffer = new byte[bufferSize];
        while (true)
        {
            int readBytes = await inputStream.ReadAsync(buffer.AsMemory(0, bufferSize));
            if (readBytes == 0)
            {
                break;
            }
            await outputStream.WriteAsync(buffer.AsMemory(0, readBytes));
        }
    }

    public static Task CopyAsyncOld(string sourceFilename,
        string destinationFilename, int bufferSize)
    {
        var inputStream = File.OpenRead(sourceFilename);
        var outputStream = File.Create(destinationFilename);

        var buffer = new byte[bufferSize];
        var onComplete = new Task(() =>
        {
            inputStream.Dispose();
            outputStream.Dispose();
        });

        void onRead(IAsyncResult readResult)
        {
            int bytesRead = inputStream.EndRead(readResult);
            if (bytesRead == 0)
            {
                onComplete.Start();
                return;
            }
            outputStream.BeginWrite(buffer, 0, bytesRead,
              writeResult =>
              {
                  outputStream.EndWrite(writeResult);
                  inputStream.BeginRead(buffer, 0, bufferSize, onRead,
        null);
              }, null);
        }

        var result = inputStream.BeginRead(buffer, 0, bufferSize,
            onRead, null);
        return onComplete;
    }
}
